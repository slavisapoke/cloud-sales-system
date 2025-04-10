namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Response;

public record CancelSubscriptionResponse(
    Guid SubscriptionId,
    bool IsSuccess,
    string? Message);
