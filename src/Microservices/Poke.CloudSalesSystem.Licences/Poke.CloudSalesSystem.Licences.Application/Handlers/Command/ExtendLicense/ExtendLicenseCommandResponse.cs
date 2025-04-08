namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence
{
    public record ExtendLicenceCommandResponse(Guid LicenceId, DateTimeOffset validTo);
}