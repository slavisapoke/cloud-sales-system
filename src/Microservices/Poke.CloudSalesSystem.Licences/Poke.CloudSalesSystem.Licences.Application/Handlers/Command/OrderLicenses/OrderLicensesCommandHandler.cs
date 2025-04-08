using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderLicences;

public class OrderLicencesCommandHandler
    : IRequestHandler<OrderLicencesCommand, IResult<OrderLicencesCommandResponse>>
{
    public async Task<IResult<OrderLicencesCommandResponse>> Handle(OrderLicencesCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<OrderLicencesCommandResponse>("Not implemented"));
    }
}
