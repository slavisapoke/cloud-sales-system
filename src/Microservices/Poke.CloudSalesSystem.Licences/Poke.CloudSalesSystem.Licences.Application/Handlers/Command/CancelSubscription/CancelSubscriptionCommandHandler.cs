using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.Subscriptions;
using Poke.CloudSalesSystem.Contracts.Events.Events.System;
using EventCodes = Poke.CloudSalesSystem.Contracts.Events.Events.Constants.Codes;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription;

public class CancelSubscriptionCommandHandler(
    HandlerParams<CancelSubscriptionCommandHandler> parameters)
    : IRequestHandler<CancelSubscriptionCommand, IResult<CancelSubscriptionCommandResponse>>
{
    public async Task<IResult<CancelSubscriptionCommandResponse>> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = parameters.DB.Subscriptions
            .Include(s => s.Licences)
            .FirstOrDefault(s => s.ServiceId == request.ServiceId && s.AccountId == request.AccountId);

        if (subscription == null)
        {
            parameters.Logger.LogWarning($"Subscription not found for {LogPlaceholders.REQUEST}", request);
            return Result.Fail<CancelSubscriptionCommandResponse>("Subscription not found for the given parameters");
        }

        var cancelResult = await parameters.CloudComputingProvider.CancelSubscription(
            subscription.ServiceId, request.AccountId, cancellationToken);


        if (cancelResult.IsFailed)
        {
            parameters.Logger.LogError($"Cancel subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}", subscription.Id);
            return Result.Fail<CancelSubscriptionCommandResponse>($"Cancel subscription failed for {subscription.ServiceName}");
        }

        var response = cancelResult.Value;

        if (!response.IsSuccess)
        {
            parameters.Logger.LogError($"Cancel subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}. {LogPlaceholders.RESPONSE}", subscription.Id, subscription.ExternalSubscriptionId);

            await parameters.EventPublisher.Publish(
                ActionFailedEvent.Create(EventCodes.Error.SOME_CODE_NAME, request,
                    "Take it or leave it"));

            return Result.Fail<CancelSubscriptionCommandResponse>($"Cancel subscription failed for {subscription.ServiceName}");
        }

        subscription.Status = Domain.Model.SubscriptionStatus.Cancelled;

        foreach (var item in subscription.Licences)
        {
            item.Status = Domain.Model.LicenceStatus.Cancelled;
        }
        
        await parameters.DB.SaveChangesAsync(cancellationToken);

        //send out event, cancel other processes related to licence cancellation
        await parameters.EventPublisher.Publish(new SubscriptionCancelled(parameters.Mapper.Map<Subscription>(subscription)));

        return Result.Ok(new
        CancelSubscriptionCommandResponse(
            subscription.Id,
            response.IsSuccess,
            response.Message
         ));
    }
}
