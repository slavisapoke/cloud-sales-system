using Poke.CloudSalesSystem.Licences.Application.Model;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService
{
    public record OrderLicencesCommandResponse(
        Guid SubscriptionId,
        Guid ServiceId,
        List<Licence> Licences);
}