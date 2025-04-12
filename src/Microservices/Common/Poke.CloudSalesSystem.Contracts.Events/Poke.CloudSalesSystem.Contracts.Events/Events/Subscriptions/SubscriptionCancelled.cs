using Poke.CloudSalesSystem.Common.Contracts.Licences;

namespace Poke.CloudSalesSystem.Contracts.Events.Events.Subscriptions;

public record SubscriptionCancelled(Subscription sub) : ICloudSalesEvent;