namespace Poke.CloudSalesSystem.Licences.Application.Model.CloudComputing;

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