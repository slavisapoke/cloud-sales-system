
using Poke.CloudSalesSystem.Common.Contracts.Licences.Enums;

namespace Poke.CloudSalesSystem.Common.Contracts.Licences;

public class Licence
{
    public required Guid Id { get; set; }
    public required Guid ExternalLicenceId { get; set; }
    public required Guid ExternalSubscriptionId { get; set; }
    public required Guid AccountId { get; set; }
    public string? LicenceKey { get; set; }
    public LicenceStatus Status { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}