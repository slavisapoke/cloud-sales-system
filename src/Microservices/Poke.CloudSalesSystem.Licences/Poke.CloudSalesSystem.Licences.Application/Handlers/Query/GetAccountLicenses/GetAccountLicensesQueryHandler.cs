using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Query.GetAccountLicences
{
    public class GetAccountLicencesQueryHandler :
        IRequestHandler<GetAccountLicencesQuery, IResult<GetAccountLicencesQueryResponse>>
    {
        public async Task<IResult<GetAccountLicencesQueryResponse>> Handle(GetAccountLicencesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Result.Fail<GetAccountLicencesQueryResponse>("Not implemented"));
        }
    }
}
