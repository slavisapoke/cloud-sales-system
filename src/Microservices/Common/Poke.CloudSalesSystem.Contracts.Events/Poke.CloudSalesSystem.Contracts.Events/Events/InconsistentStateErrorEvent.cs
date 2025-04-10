namespace Poke.CloudSalesSystem.Contracts.Events.Events;

public record InconsistentStateErrorEvent(
    Guid SubscriptionId, string Reason);
