namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Request;

public record ExtendLicenceRequest(Guid AccountId, Guid LicenceId, DateTimeOffset Until);
