namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.ExtendLicense
{
    public record ExtendLicenseCommandResponse(Guid LicenseId, DateTimeOffset validTo);
}