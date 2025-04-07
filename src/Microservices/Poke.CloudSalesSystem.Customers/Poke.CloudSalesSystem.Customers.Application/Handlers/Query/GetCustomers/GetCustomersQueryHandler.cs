using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Customers.Application.Model;

namespace Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCase;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, Result<IEnumerable<Customer>>>
{
    public async Task<Result<IEnumerable<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult<List<Customer>>(new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Slavisa Pokimica"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Makedonsko Devojce"
            }
        });
    }
}
