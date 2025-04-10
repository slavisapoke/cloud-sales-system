using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Common.Contracts.Accounts;

namespace Poke.CloudSalesSystem.Accounts.Application.Handlers.Query.GetCustomers;

public record GetAccountsQuery(Guid CustomerId) : IRequest<Result<IEnumerable<Account>>>;
