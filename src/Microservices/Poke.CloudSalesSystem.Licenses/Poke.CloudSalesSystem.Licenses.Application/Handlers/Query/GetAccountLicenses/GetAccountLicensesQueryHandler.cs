using FluentResults;
using MediatR;

namespace Poke.CloudSalesSystem.Licenses.Application.Handlers.Query.GetAccountLicenses
{
    public class GetAccountLicensesQueryHandler :
        IRequestHandler<GetAccountLicensesQuery, IResult<GetAccountLicensesQueryResponse>>
    {
        public async Task<IResult<GetAccountLicensesQueryResponse>> Handle(GetAccountLicensesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Result.Fail<GetAccountLicensesQueryResponse>("Not implemented"));
        }
    }
}
