using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.OrderService;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.OrderLicenses;

public class OrderLicensesCommandHandler
    : IRequestHandler<OrderLicensesCommand, IResult<OrderLicensesCommandResponse>>
{
    public async Task<IResult<OrderLicensesCommandResponse>> Handle(OrderLicensesCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<OrderLicensesCommandResponse>("Not implemented"));
    }
}
