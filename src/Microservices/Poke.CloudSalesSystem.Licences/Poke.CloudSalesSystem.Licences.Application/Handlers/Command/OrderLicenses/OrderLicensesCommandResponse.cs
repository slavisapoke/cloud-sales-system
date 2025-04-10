using Poke.CloudSalesSystem.Licences.Application.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService;

public record OrderLicencesCommandResponse(
    Guid AccountId,
    Guid SubscriptionId,
    Guid ServiceId,
    List<Licence> Licences,
    OrderLicencesStatus Status,
    string? Reason);

public enum OrderLicencesStatus
{
    NewSubscription,
    LicencesAquired,
    LicencesAquiredPartially,
    OrderFailed
}