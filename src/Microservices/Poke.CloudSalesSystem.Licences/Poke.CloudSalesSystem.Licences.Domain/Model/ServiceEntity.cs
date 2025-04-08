using Poke.CloudSalesSystem.Common.Database.Abstraction;

namespace Poke.CloudSalesSystem.Licences.Domain.Model;

public class ServiceEntity : Entity<Guid>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProviderId { get; set; }

    public ICollection<SubscriptionEntity> Subscriptions { get; } = [];

}
