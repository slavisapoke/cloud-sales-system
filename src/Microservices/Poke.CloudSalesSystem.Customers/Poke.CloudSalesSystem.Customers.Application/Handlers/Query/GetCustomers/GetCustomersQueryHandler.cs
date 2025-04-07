using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Customers.Application.Model;
using Poke.CloudSalesSystem.Customers.Domain.Repository;

namespace Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCase;

public class GetCustomersQueryHandler(
    ICustomerDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetCustomersQuery, Result<IEnumerable<Customer>>>
{
    public async Task<Result<IEnumerable<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await dbContext.Customers.ToListAsync();
        return mapper.Map<List<Customer>>(customers);
    }
}
