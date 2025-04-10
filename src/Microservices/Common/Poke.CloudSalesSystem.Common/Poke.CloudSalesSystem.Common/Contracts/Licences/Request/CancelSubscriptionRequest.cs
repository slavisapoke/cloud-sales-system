namespace Poke.CloudSalesSystem.Common.Contracts.Licences.Request;

public record CancelSubscriptionRequest (Guid AccountId, Guid ServiceId);
