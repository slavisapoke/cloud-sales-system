using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Accounts.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Accounts.Application.Model;
using Poke.CloudSalesSystem.Accounts.Domain.Repository;

namespace Poke.CloudSalesSystem.Accounts.Application.Handlers.Query.GetCase;

public class GetAccountsQueryHandler(
    IAccountsDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetAccountsQuery, Result<IEnumerable<Account>>>
{
    public async Task<Result<IEnumerable<Account>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var accounts = await dbContext.Accounts
            .Where(a => a.CustomerId == request.CustomerId)
            .ToListAsync();

        return mapper.Map<List<Account>>(accounts);
    }
}
