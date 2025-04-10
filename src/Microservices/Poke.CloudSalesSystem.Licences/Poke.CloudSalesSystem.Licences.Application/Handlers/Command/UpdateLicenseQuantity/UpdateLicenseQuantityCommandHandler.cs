using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;

public class UpdateLicenceQuantityCommandHandler(
    ICloudComputingProvider provider,
    ILicencesDbContext dbContext,
    ILogger<UpdateLicenceQuantityCommandHandler> logger)
    : IRequestHandler<UpdateLicenceQuantityCommand, IResult<UpdateLicenceQuantityCommandResponse>>
{
    public async Task<IResult<UpdateLicenceQuantityCommandResponse>> Handle(UpdateLicenceQuantityCommand request, CancellationToken cancellationToken)
    {
        var subscription = dbContext.Subscriptions.FirstOrDefault(s =>
            s.ServiceId == request.ServiceId && s.AccountId == request.AccountId);

        if (subscription == null)
        {
            logger.LogWarning($"Subscription not found for {LogPlaceholders.REQUEST}", request);
            return Result.Fail<UpdateLicenceQuantityCommandResponse>("Subscription not found for the given parameters");
        }

        var cancelResult = await provider.UpdateLicenceQuantity(
            subscription.ServiceId, request.AccountId, request.NewQuantity, cancellationToken);

        if (cancelResult.IsFailed)
        {
            logger.LogError($"Update subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}", subscription.Id);
            return Result.Fail<UpdateLicenceQuantityCommandResponse>($"Update subscription failed for {subscription.ServiceName}");
        }

        var response = cancelResult.Value;

        if (!response.IsSuccess)
        {
            logger.LogError($"Update subscription failed for {LogPlaceholders.SUBSCRIPTION_ID}. {LogPlaceholders.RESPONSE}", subscription.Id, response);
            return Result.Fail<UpdateLicenceQuantityCommandResponse>($"Update subscription failed for {subscription.ServiceName}");
        }

        subscription.Quantity = request.NewQuantity;

        await dbContext.SaveChangesAsync(cancellationToken);

        //send out event, someone wants to know

        return Result.Ok(new
            UpdateLicenceQuantityCommandResponse(
                subscription.Id,
                response.IsSuccess,
                response.Message
             ));
    }
}
