namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

public record UpdateLicenceQuantityResponse(
    Guid SubscriptionId,
    bool IsSuccess,
    string? Message);