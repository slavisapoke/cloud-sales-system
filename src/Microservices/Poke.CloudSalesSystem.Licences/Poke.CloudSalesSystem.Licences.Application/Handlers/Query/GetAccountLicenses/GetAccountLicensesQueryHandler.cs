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

            var result = await dbContext.Subscriptions
                .Include(s => s.Licences)
                .Where(s => s.AccountId == request.AccountId)
                .ToListAsync();

            response.Subscriptions.AddRange(result is null ? [] : mapper.Map<List<Subscription>>(result));

            List<Licence> licences = result is null ?
                [] : mapper.Map<List<Licence>>(result.SelectMany(s => s.Licences).ToList());

            response.Licences.AddRange(licences);

            return Result.Ok(response);
        }
    }
}
