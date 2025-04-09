using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Licences.Application.Model;
using Poke.CloudSalesSystem.Licences.Domain.Repository;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Query.GetAccountLicences
{
    public class GetAccountLicencesQueryHandler(
        ILicencesDbContext dbContext,
        IMapper mapper) :
        IRequestHandler<GetAccountLicencesQuery, IResult<GetAccountLicencesQueryResponse>>
    {
        public async Task<IResult<GetAccountLicencesQueryResponse>> Handle(GetAccountLicencesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAccountLicencesQueryResponse { AccountId = request.AccountId };

            var licences = await dbContext.Licences
                .Where(l => l.AccountId == request.AccountId)
                .ToListAsync();

            response.Licences.AddRange(mapper.Map<List<Licence>>(licences));

            return Result.Ok(response);
        }
    }
}
