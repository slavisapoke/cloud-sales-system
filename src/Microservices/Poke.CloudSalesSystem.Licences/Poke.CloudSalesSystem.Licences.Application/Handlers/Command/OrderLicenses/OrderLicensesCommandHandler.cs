using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.System;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService;
using Poke.CloudSalesSystem.Licences.Application.Model.Wrapper;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderLicences;

public class OrderLicencesCommandHandler(
    HandlerParams<OrderLicencesCommandHandler> parameters
    ) : IRequestHandler<OrderLicencesCommand, IResult<OrderLicencesCommandResponse>>
{
    public async Task<IResult<OrderLicencesCommandResponse>> Handle(OrderLicencesCommand request, CancellationToken cancellationToken)
    {
        var subscriptionInfo = await GetSubscriptionInfo(request.AccountId, request.ServiceId);

        if (!IsValid(subscriptionInfo, out var error))
        {
            parameters.Logger.LogError($"{LogPlaceholders.ORDER} failed with error: {LogPlaceholders.ERROR}", request, error);
            return Result.Fail<OrderLicencesCommandResponse>(error);
        }

        var ccResult = await parameters.CloudComputingProvider.OrderLicences(
                request.AccountId, request.ServiceId, request.Quantity,
                cancellationToken);

        if (ccResult.IsFailed)
        {
            parameters.Logger.LogError($"For {LogPlaceholders.ORDER} service provider responded with error: {LogPlaceholders.ERROR}", request, error);
            return Result.Fail<OrderLicencesCommandResponse>(ccResult.Errors);
        }

        var response = ccResult.Value;

        if (response.Status == OrderStatus.OrderFailed)
        {
            parameters.Logger.LogError($"For {LogPlaceholders.ORDER} service provider responded with {response.Status}. Error: {LogPlaceholders.ERROR}", request, error);
            return Result.Fail<OrderLicencesCommandResponse>(response.Reason);
        }

        var dbLicences = parameters.Mapper.Map<IEnumerable<LicenceEntity>>(ccResult.Value.Licences);
        
        var subscription = parameters.DB.Subscriptions.FirstOrDefault(s => s.ExternalSubscriptionId == response.SubscriptionId);
        var newSubscription = response.Status == OrderStatus.NewSubscription;

        if (newSubscription && subscription != null)
        {
            var msg = $"Subscription {response.SubscriptionId} already exist in the system. Provider status: {response.Status}";
            parameters.Logger.LogWarning(msg);

            await parameters.EventPublisher.Publish(new InconsistentEntityState<Subscription>(msg,
                parameters.Mapper.Map<Subscription>(subscription)));

            return Result.Fail<OrderLicencesCommandResponse>("Account already contains subscription but the provider reports new..");
        }
       
        subscription = subscription ?? new SubscriptionEntity
        {
            ExternalSubscriptionId = response.SubscriptionId,
            Quantity = request.Quantity,
            AccountId = request.AccountId,
            ServiceId = response.ServiceId,
            ServiceName = response.ServiceName,
            Status = SubscriptionStatus.Active
        };

        if (newSubscription) parameters.DB.Subscriptions.Add(subscription);

        foreach (var licence in dbLicences)
        {
            licence.ExternalSubscriptionId = response.SubscriptionId;
            licence.AccountId = request.AccountId;
            subscription.Licences.Add(licence);
        }

        parameters.DB.Licences.AddRange(dbLicences);

        await parameters.DB.SaveChangesAsync(cancellationToken);

        //Send message to event bus for further processing
        await parameters.EventPublisher.Publish(new LicensesCreated(parameters.Mapper.Map<IReadOnlyCollection<Licence>>(dbLicences)));

        var result = new OrderLicencesCommandResponse(request.AccountId,
            response.SubscriptionId,
            response.ServiceId,
            parameters.Mapper.Map<List<Licence>>(dbLicences),
            (OrderLicencesStatus)response.Status,
            response.Reason);

        return Result.Ok(result);
    }

    private async Task<SubscriptionInfo?> GetSubscriptionInfo(Guid accountId, Guid serviceId)
    {
        var dbResult = await parameters.DB.Subscriptions
             .Where(s => s.AccountId == accountId && s.ServiceId == serviceId)
             .Select(s => new SubscriptionInfo(
                 s,
                 s.Licences.Count(),
                 s.Licences
                   .Count(s => s.Status == LicenceStatus.Active && s.ValidTo > parameters.TimeProvider.GetUtcNow())
             )).FirstOrDefaultAsync();

        return dbResult;
    }

    private bool IsValid(SubscriptionInfo? subscriptionInfo, out string error)
    {
        if (subscriptionInfo != null)
        {
            if (subscriptionInfo.Subscription.Status != SubscriptionStatus.Active)
            {
                error =  $"You cannot request licences for non-active subscription. Subscription status: {subscriptionInfo.Subscription.Status}" ;
                return false;
            }

            if (subscriptionInfo.NumberOfActiveLicences == subscriptionInfo.Subscription.Quantity)
            {
                error = $"All licences for this subscription are active";
                return false;
            }
        }
            
        error = string.Empty;
        return true;
    }
}
