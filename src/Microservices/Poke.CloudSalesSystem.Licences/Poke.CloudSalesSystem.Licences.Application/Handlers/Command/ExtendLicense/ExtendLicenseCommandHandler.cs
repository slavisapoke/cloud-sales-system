using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using Poke.CloudSalesSystem.Common.Contracts.Licences;
using Poke.CloudSalesSystem.Contracts.Events.Events.Licences;
using Poke.CloudSalesSystem.Licences.Domain.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence;

public class ExtendLicenceCommandHandler(
    HandlerParams<ExtendLicenceCommandHandler> parameters):
    IRequestHandler<ExtendLicenceCommand, IResult<ExtendLicenceCommandResponse>>
{
    public async Task<IResult<ExtendLicenceCommandResponse>> Handle(
        ExtendLicenceCommand request, CancellationToken cancellationToken)
    {
        var licenceDb = parameters.DB.Licences.FirstOrDefault(l => l.Id == request.LicenceId);

        if (!Validate(licenceDb, request, out var message))
        {
            return Result.Fail<ExtendLicenceCommandResponse>(message);
        }

        var ccResult = await parameters.CloudComputingProvider.ExtendLicence(licenceDb!.ExternalLicenceId, request.AccountId, request.Until,
            cancellationToken);

        if (ccResult.IsFailed)
        {
            parameters.Logger.LogError($"Extend licence failed for {LogPlaceholders.LICENCE_ID} with {LogPlaceholders.ERROR}", request.LicenceId, ccResult.Errors);
            return Result.Fail<ExtendLicenceCommandResponse>($"Extend licence failed: {ccResult.Errors}");
        }

        var response = ccResult.Value;

        if (!response.IsSuccess)
        {
            parameters.Logger.LogError($"Extend licence failed for {LogPlaceholders.LICENCE_ID} with : {response.Message}", request.LicenceId);
            return Result.Fail<ExtendLicenceCommandResponse>($"Extend licence failed with message: {response.Message}");
        }

        licenceDb.Status = LicenceStatus.Active;
        licenceDb.ValidTo = request.Until;

        await parameters.DB.SaveChangesAsync();

        //SEND EVENT
        await parameters.EventPublisher.Publish(new LicensesExtended(parameters.Mapper.Map<Licence>(licenceDb)));
         
        var result = new ExtendLicenceCommandResponse(request.LicenceId, request.Until);
        return Result.Ok(result);
    }

    private bool Validate(LicenceEntity? licence, ExtendLicenceCommand request, out string message)
    {
        message = string.Empty;

        if (licence == null)
        {
            parameters.Logger.LogError($"Licence {LogPlaceholders.LICENCE_ID} not found.", request.LicenceId);
            message = "Licence not found";
            return false;
        }

        if (licence.AccountId != request.AccountId)
        {
            parameters.Logger.LogError($"Licence {LogPlaceholders.LICENCE_ID} deos not belong to account {LogPlaceholders.ACCOUNT_ID}.", request.LicenceId, request.AccountId);
            message = "Given account is not owner of the licence";
            return false;
        }

        if (licence.Status == LicenceStatus.Active && licence.ValidTo > request.Until)
        {
            parameters.Logger.LogError($"Licence {LogPlaceholders.LICENCE_ID} is active and valid after given extend period.", request.LicenceId);
            message = "Given licence is active and valid after given extend period.";
            return false;
        }
        
        return true;
    }
}
