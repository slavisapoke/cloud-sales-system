namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

public record ExtendLicenceResponse(Guid LicenceId, DateTimeOffset validTo);