namespace Poke.CloudSalesSystem.Licences.Application.Model;

public class Licence
{
    public required Guid Id { get; set; }
    public required Guid ExternalLicenceId { get; set; }
    public required Guid ExternalSubscriptionId { get; set; }
    public required Guid AccountId { get; set; }
    public string? LicenceKey { get; set; }
    public int Status { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
