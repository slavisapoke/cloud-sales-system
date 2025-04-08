using Poke.CloudSalesSystem.Common.Database.Abstraction;

namespace Poke.CloudSalesSystem.Licences.Domain.Model;

public class LicenceEntity : Entity<Guid>
{
    public required Guid ExternalLicenceId { get; set; }
    public required Guid ExternalSubscriptionId { get; set; }
    public Guid? AccountId { get; set; }
    public string? LicenceKey { get; set; }
    public LicenceStatus Status { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public required Guid SubscriptionId { get; set; }

    public SubscriptionEntity Subscription { get; private set; } = null!;
}

public enum LicenceStatus
{
    Active = 1,
    Inactive,
    Expired,
    Suspended,
    //...//
    Cancelled = 100
}
