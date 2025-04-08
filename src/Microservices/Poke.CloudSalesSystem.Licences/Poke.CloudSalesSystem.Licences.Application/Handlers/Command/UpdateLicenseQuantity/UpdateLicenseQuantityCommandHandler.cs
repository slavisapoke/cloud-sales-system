using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;

public class UpdateLicenceQuantityCommandHandler
    : IRequestHandler<UpdateLicenceQuantityCommand, IResult<UpdateLicenceQuantityCommandResponse>>
{
    public async Task<IResult<UpdateLicenceQuantityCommandResponse>> Handle(UpdateLicenceQuantityCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<UpdateLicenceQuantityCommandResponse>("Not implemented"));
    }
}
