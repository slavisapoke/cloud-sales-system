using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Command.UpdateLicenseQuantity;

public class UpdateLicenseQuantityCommandHandler
    : IRequestHandler<UpdateLicenseQuantityCommand, IResult<UpdateLicenseQuantityCommandResponse>>
{
    public async Task<IResult<UpdateLicenseQuantityCommandResponse>> Handle(UpdateLicenseQuantityCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Result.Fail<UpdateLicenseQuantityCommandResponse>("Not implemented"));
    }
}
