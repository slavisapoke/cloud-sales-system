using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.Subscriptions;
using Poke.CloudSalesSystem.Contracts.Events.Events.System;
using EventCodes = Poke.CloudSalesSystem.Contracts.Events.Events.Constants.Codes;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;

public class UpdateLicenceQuantityCommandHandler(
    HandlerParams<UpdateLicenceQuantityCommandHandler> parameters)
    : IRequestHandler<UpdateLicenceQuantityCommand, IResult<UpdateLicenceQuantityCommandResponse>>
{
    public async Task<IResult<UpdateLicenceQuantityCommandResponse>> Handle(UpdateLicenceQuantityCommand request, CancellationToken cancellationToken)
    {
        var subscription = parameters.DB.Subscriptions.FirstOrDefault(s =>
            s.ServiceId == request.ServiceId && s.AccountId == request.AccountId);

        if (subscription == null)
        {
            parameters.Logger.LogWarning($"Subscription not found for {LogPlaceholders.REQUEST}", request);
            return Result.Fail<UpdateLicenceQuantityCommandResponse>("Subscription not found for the given parameters");
        }

        var cancelResult = await parameters.CloudComputingProvider.UpdateLicenceQuantity(
            subscription.ServiceId, request.AccountId, request.NewQuantity, cancellationToken);

        if (cancelResult.IsFailed)
        {
            parameters.Logger.LogError($"Update subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}", subscription.Id);
            
            await parameters.EventPublisher.Publish(
                ActionFailedEvent.Create(EventCodes.Error.HELL_AND_FIRE, request,
                    "Take it or leave it"));

            return Result.Fail<UpdateLicenceQuantityCommandResponse>($"Update subscription failed for {subscription.ServiceName}");
        }

        var response = cancelResult.Value;

        if (!response.IsSuccess)
        {
            parameters.Logger.LogError($"Update subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}. {LogPlaceholders.RESPONSE}", subscription.Id, response);
            return Result.Fail<UpdateLicenceQuantityCommandResponse>($"Update subscription failed for {subscription.ServiceName}");
        }

        subscription.Quantity = request.NewQuantity;

        await parameters.DB.SaveChangesAsync(cancellationToken);

        //send out event, someone wants to know
        await parameters.EventPublisher.Publish(new SubscriptionQuantityChanged(
            parameters.Mapper.Map<Subscription>(subscription)));

        return Result.Ok(new
            UpdateLicenceQuantityCommandResponse(
                subscription.Id,
                response.IsSuccess,
                response.Message
             ));
    }
}
