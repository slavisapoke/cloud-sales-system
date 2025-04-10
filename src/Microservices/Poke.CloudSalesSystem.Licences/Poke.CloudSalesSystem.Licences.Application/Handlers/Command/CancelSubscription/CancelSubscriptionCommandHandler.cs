using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription;

public class CancelSubscriptionCommandHandler(
    ILogger<CancelSubscriptionCommandHandler> logger,
    ICloudComputingProvider provider,
    ILicencesDbContext dbContext)
    : IRequestHandler<CancelSubscriptionCommand, IResult<CancelSubscriptionCommandResponse>>
{
    public async Task<IResult<CancelSubscriptionCommandResponse>> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = dbContext.Subscriptions
            .Include(s => s.Licences)
            .FirstOrDefault(s => s.ServiceId == request.ServiceId && s.AccountId == request.AccountId);

        if (subscription == null)
        {
            logger.LogWarning($"Subscription not found for {LogPlaceholders.REQUEST}", request);
            return Result.Fail<CancelSubscriptionCommandResponse>("Subscription not found for the given parameters");
        }

        var cancelResult = await provider.CancelSubscription(
            subscription.ServiceId, request.AccountId, cancellationToken);


        if (cancelResult.IsFailed)
        {
            logger.LogError($"Cancel subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}", subscription.Id);
            return Result.Fail<CancelSubscriptionCommandResponse>($"Cancel subscription failed for {subscription.ServiceName}");
        }

        var response = cancelResult.Value;

        if (!response.IsSuccess)
        {
            logger.LogError($"Cancel subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}. {LogPlaceholders.RESPONSE}", subscription.Id, subscription.ExternalSubscriptionId);
            return Result.Fail<CancelSubscriptionCommandResponse>($"Cancel subscription failed for {subscription.ServiceName}");
        }

        subscription.Status = Domain.Model.SubscriptionStatus.Cancelled;

        foreach (var item in subscription.Licences)
        {
            item.Status = Domain.Model.LicenceStatus.Cancelled;
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);

        //send out event, cancel other processes related to licence cancellation

        return Result.Ok(new
        CancelSubscriptionCommandResponse(
            subscription.Id,
            response.IsSuccess,
            response.Message
         ));
    }
}
