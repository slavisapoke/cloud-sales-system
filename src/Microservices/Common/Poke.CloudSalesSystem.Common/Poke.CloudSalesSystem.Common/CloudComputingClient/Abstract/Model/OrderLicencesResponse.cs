namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

public record OrderLicencesResponse(
    Guid SubscriptionId,
    Guid ServiceId,
    string ServiceName,
    IEnumerable<CloudComputingLicence> Licences,
    OrderStatus Status,
    string? Reason);

public enum OrderStatus
{
    NewSubscription,
    LicencesAquired,
    LicencesAquiredPartially,
    OrderFailed
}