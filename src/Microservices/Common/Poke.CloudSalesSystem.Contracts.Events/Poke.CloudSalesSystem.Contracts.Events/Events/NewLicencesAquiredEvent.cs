namespace Poke.CloudSalesSystem.Contracts.Events.Broker;

public record NewLicencesAquiredEvent(Guid AccountId, Guid SubscriptionId, IReadOnlyCollection<Guid> licences);