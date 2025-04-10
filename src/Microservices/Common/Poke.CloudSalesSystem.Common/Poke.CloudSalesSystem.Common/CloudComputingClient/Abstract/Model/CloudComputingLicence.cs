
namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

public class CloudComputingLicence
{
    public required Guid Id { get; set; }
    public required Guid SubscriptionId { get; set; }
    public string? LicenceKey { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}

public enum Status
{
    Active = 1,
    Inactive,
    Expired,
    Suspended,
    //...//
    Cancelled = 100
}