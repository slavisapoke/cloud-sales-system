namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.OrderService;

public record OrderLicensesCommand(Guid AccountId, Guid ServiceId, int Quantity)
    : IRequestWithFluentResult<OrderLicensesCommandResponse>;