using Poke.CloudSalesSystem.Common.Database.Abstraction;

namespace Poke.CloudSalesSystem.Licences.Domain.Model;

public class SubscriptionEntity : Entity<Guid>
{
    public required Guid ExternalSubscriptionId { get; set; }
    public required Guid AccountId { get; set; }
    public required Guid ServiceId { get; set; }
    public required string ServiceName { get; set; }
    public required int Quantity { get; set; } = 1;
    public SubscriptionStatus Status { get; set; }

    public ServiceEntity Service { get; private set; } = null!;
    public ICollection<LicenceEntity> Licences { get; } = [];
}

public enum SubscriptionStatus
{
    Active = 1,
    Inactive,
    Expired,
    Suspended,
    //...//
    Cancelled = 100
}
