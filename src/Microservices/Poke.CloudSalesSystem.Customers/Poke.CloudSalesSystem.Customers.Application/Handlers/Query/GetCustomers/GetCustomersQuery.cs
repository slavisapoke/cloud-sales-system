using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Common.Contracts.Customers;

namespace Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCustomers;

public record GetCustomersQuery() : IRequest<Result<IEnumerable<Customer>>>;
