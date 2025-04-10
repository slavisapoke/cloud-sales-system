using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription;
using Poke.CloudSalesSystem.Licences.Application.Model;
using Poke.CloudSalesSystem.Licences.Domain.Model;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence;

public class ExtendLicenceCommandHandler(
    ICloudComputingProvider provider,
    ILicencesDbContext dbContext,
    ILogger<ExtendLicenceCommandHandler> logger):
    IRequestHandler<ExtendLicenceCommand, IResult<ExtendLicenceCommandResponse>>
{
    public async Task<IResult<ExtendLicenceCommandResponse>> Handle(
        ExtendLicenceCommand request, CancellationToken cancellationToken)
    {
        var licenceDb = dbContext.Licences.FirstOrDefault(l => l.Id == request.LicenceId);

        if (!Validate(licenceDb, request, out var message))
        {
            return Result.Fail<ExtendLicenceCommandResponse>(message);
        }

        var ccResult = await provider.ExtendLicence(licenceDb!.ExternalLicenceId, request.AccountId, request.Until,
            cancellationToken);

        if (ccResult.IsFailed)
        {
            logger.LogError($"Extend licence failed for {LogPlaceholders.LICENCE_ID} with {LogPlaceholders.ERROR}", request.LicenceId, ccResult.Errors);
            return Result.Fail<ExtendLicenceCommandResponse>($"Extend licence failed: {ccResult.Errors}");
        }

        var response = ccResult.Value;

        if (!response.IsSuccess)
        {
            logger.LogError($"Extend licence failed for {LogPlaceholders.LICENCE_ID} with : {response.Message}", request.LicenceId);
            return Result.Fail<ExtendLicenceCommandResponse>($"Extend licence failed with message: {response.Message}");
        }

        licenceDb.Status = LicenceStatus.Active;
        licenceDb.ValidTo = request.Until;

        await dbContext.SaveChangesAsync();

        //send event message to bus

        var result = new ExtendLicenceCommandResponse(request.LicenceId, request.Until);
        return Result.Ok(result);
    }

    private bool Validate(LicenceEntity? licence, ExtendLicenceCommand request, out string message)
    {
        message = string.Empty;

        if (licence == null)
        {
            logger.LogError($"Licence {LogPlaceholders.LICENCE_ID} not found.", request.LicenceId);
            message = "Licence not found";
            return false;
        }

        if (licence.AccountId != request.AccountId)
        {
            logger.LogError($"Licence {LogPlaceholders.LICENCE_ID} deos not belong to account {LogPlaceholders.ACCOUNT_ID}.", request.LicenceId, request.AccountId);
            message = "Given account is not owner of the licence";
            return false;
        }

        if (licence.Status == LicenceStatus.Active && licence.ValidTo > request.Until)
        {
            logger.LogError($"Licence {LogPlaceholders.LICENCE_ID} is active and valid after given extend period.", request.LicenceId);
            message = "Given licence is active and valid after given extend period.";
            return false;
        }
        
        return true;
    }
}
