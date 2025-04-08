using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Accounts.Application.Model;

namespace Poke.CloudSalesSystem.Accounts.Application.Handlers.Query.GetCustomers;

public record GetAccountsQuery(Guid CustomerId) : IRequest<Result<IEnumerable<Account>>>;
