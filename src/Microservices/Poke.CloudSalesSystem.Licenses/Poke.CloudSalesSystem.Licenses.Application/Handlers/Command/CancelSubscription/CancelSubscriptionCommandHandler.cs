using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.CancelSubscription;

public class CancelSubscriptionCommandHandler
    : IRequestHandler<CancelSubscriptionCommand, IResult<CancelSubscriptionCommandResponse>>
{
    public async Task<IResult<CancelSubscriptionCommandResponse>> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<CancelSubscriptionCommandResponse>("Not implemented"));
    }
}
