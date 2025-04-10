namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Request;

public record OrderLicencesRequest(Guid AccountId, Guid ServiceId, int Quantity);