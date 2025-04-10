namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence;

public record ExtendLicenceCommand(Guid AccountId, Guid LicenceId, DateTimeOffset Until)
    : IRequestWithFluentResult<ExtendLicenceCommandResponse>;
