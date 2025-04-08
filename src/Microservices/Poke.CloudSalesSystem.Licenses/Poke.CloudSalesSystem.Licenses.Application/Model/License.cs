namespace Poke.CloudSalesSystem.Licenses.Application.Model;

public class License
{
    public required Guid Id { get; set; }
    public required Guid ExternalLicenseId { get; set; }
    public required Guid ExternalSubscriptionId { get; set; }
    public required Guid AccountId { get; set; }
    public string? LicenseKey { get; set; }
    public int Status { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
