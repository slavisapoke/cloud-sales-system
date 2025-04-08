namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.ExtendLicense;

public record ExtendLicenseCommand(Guid AccountId, Guid LicenseId)
    : IRequestWithFluentResult<ExtendLicenseCommandResponse>;
