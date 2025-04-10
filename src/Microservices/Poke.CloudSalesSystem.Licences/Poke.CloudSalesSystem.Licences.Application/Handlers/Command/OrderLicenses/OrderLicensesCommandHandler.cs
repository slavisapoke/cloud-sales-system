using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Licences.Application.Abstraction;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService;
using Poke.CloudSalesSystem.Licences.Application.Model;
using Poke.CloudSalesSystem.Licences.Application.Model.Wrapper;
using Poke.CloudSalesSystem.Licences.Domain.Model;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderLicences;

public class OrderLicencesCommandHandler(
    IMapper mapper,
    TimeProvider timeProvider,
    ILicencesDbContext dbContext,
    ICloudComputingProvider cloudComputingProvider,
    ILogger<OrderLicencesCommandHandler> logger
    ) : IRequestHandler<OrderLicencesCommand, IResult<OrderLicencesCommandResponse>>
{
    public async Task<IResult<OrderLicencesCommandResponse>> Handle(OrderLicencesCommand request, CancellationToken cancellationToken)
    {
        var subscriptionInfo = await GetSubscriptionInfo(request.AccountId, request.ServiceId);

        if (!IsValid(subscriptionInfo, out var error))
        {
            logger.LogError($"{LogPlaceholders.ORDER} failed with error: {LogPlaceholders.ERROR}", request, error);
            return Result.Fail<OrderLicencesCommandResponse>(error);
        }

        var ccResult = await cloudComputingProvider.OrderLicences(
                request.AccountId, request.ServiceId, request.Quantity,
                cancellationToken);

        if (ccResult.IsFailed)
        {
            logger.LogError($"For {LogPlaceholders.ORDER} service provider responded with error: {LogPlaceholders.ERROR}", request, error);
            return Result.Fail<OrderLicencesCommandResponse>(ccResult.Errors);
        }

        var response = ccResult.Value;

        if (response.Status == Model.CloudComputing.OrderStatus.OrderFailed)
        {
            logger.LogError($"For {LogPlaceholders.ORDER} service provider responded with {response.Status}. Error: {LogPlaceholders.ERROR}", request, error);
            return Result.Fail<OrderLicencesCommandResponse>(response.Reason);
        }

        var dbLicences = mapper.Map<IEnumerable<LicenceEntity>>(ccResult.Value.Licences);
        
        var subscription = dbContext.Subscriptions.FirstOrDefault(s => s.ExternalSubscriptionId == response.SubscriptionId);
        var newSubscription = response.Status == Model.CloudComputing.OrderStatus.NewSubscription;

        if (newSubscription && subscription != null)
        {
            logger.LogWarning($"Subscription {response.SubscriptionId} already exist in the system. Provider status: {response.Status}");
            //send message event, incosistent data between css and ccp?
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

        if (newSubscription) dbContext.Subscriptions.Add(subscription);

        foreach (var licence in dbLicences)
        {
            licence.ExternalSubscriptionId = response.SubscriptionId;
            licence.AccountId = request.AccountId;
            subscription.Licences.Add(licence);
        }

        dbContext.Licences.AddRange(dbLicences);

        try
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return Result.Fail<OrderLicencesCommandResponse>(ex.Message);
        }
        //Send message to event bus for further processing

        var result = new OrderLicencesCommandResponse(request.AccountId,
            response.SubscriptionId,
            response.ServiceId,
            mapper.Map<List<Licence>>(dbLicences),
            (OrderLicencesStatus)response.Status,
            response.Reason);

        return Result.Ok(result);
    }

    private async Task<SubscriptionInfo?> GetSubscriptionInfo(Guid accountId, Guid serviceId)
    {
        var dbResult = await dbContext.Subscriptions
             .Where(s => s.AccountId == accountId && s.ServiceId == serviceId)
             .Select(s => new SubscriptionInfo(
                 s,
                 s.Licences.Count(),
                 s.Licences
                   .Count(s => s.Status == LicenceStatus.Active && s.ValidTo > timeProvider.GetUtcNow())
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
