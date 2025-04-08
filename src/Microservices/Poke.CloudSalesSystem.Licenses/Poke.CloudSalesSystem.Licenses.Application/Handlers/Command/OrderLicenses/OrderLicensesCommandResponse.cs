using Poke.CloudSalesSystem.Licenses.Application.Model;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.OrderService
{
    public record OrderLicensesCommandResponse(
        Guid SubscriptionId,
        Guid ServiceId,
        List<License> Licenses);
}