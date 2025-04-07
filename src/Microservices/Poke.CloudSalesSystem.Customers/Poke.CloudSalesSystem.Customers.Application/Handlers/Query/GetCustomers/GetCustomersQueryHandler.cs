using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Contracts.Events.Broker;
using Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Customers.Application.Model;

namespace Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCase;

public class GetCustomersQueryHandler(
    ILogger<GetCustomersQueryHandler> logger) : IRequestHandler<GetCustomersQuery, Result<IEnumerable<Customer>>>
{
    public async Task<Result<IEnumerable<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation(new TestEvent().ToString());

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
