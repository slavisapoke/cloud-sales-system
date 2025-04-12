using MassTransit.Courier.Contracts;

namespace Poke.CloudSalesSystem.Contracts.Events.Events.Subscriptions;

public record SubscriptionsSuspended(
    IReadOnlyCollection<Subscription> subscriptions,
    string Reason) : ICloudSalesEvent;
