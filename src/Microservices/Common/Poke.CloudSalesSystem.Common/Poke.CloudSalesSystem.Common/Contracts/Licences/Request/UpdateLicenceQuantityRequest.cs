namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Request;

public record UpdateLicenceQuantityRequest(Guid ServiceId, Guid AccountId, int NewQuantity);

