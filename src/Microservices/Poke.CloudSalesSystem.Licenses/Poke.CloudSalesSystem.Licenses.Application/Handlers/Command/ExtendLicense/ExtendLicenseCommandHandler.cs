using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.ExtendLicense;

public class ExtendLicenseCommandHandler :
    IRequestHandler<ExtendLicenseCommand, IResult<ExtendLicenseCommandResponse>>
{
    public async Task<IResult<ExtendLicenseCommandResponse>> Handle(
        ExtendLicenseCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<ExtendLicenseCommandResponse>("Not implemented"));
    }
}
