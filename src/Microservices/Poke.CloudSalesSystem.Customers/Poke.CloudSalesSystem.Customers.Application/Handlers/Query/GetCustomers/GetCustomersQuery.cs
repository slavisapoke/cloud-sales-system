using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Customers.Application.Model;

namespace Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCustomers;

public record GetCustomersQuery() : IRequest<Result<IEnumerable<Customer>>>;
