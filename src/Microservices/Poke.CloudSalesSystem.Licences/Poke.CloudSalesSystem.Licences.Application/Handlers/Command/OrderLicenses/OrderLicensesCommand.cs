namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService;

public record OrderLicencesCommand(Guid AccountId, Guid ServiceId, int Quantity)
    : IRequestWithFluentResult<OrderLicencesCommandResponse>;