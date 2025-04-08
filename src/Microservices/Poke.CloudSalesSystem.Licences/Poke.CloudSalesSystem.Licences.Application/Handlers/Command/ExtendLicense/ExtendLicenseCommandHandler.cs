using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence;

public class ExtendLicenceCommandHandler :
    IRequestHandler<ExtendLicenceCommand, IResult<ExtendLicenceCommandResponse>>
{
    public async Task<IResult<ExtendLicenceCommandResponse>> Handle(
        ExtendLicenceCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<ExtendLicenceCommandResponse>("Not implemented"));
    }
}
