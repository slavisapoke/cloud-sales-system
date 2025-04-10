using Poke.CloudSalesSystem.Common.Contracts.Accounts;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

public interface IAccountService
{
    Task<IReadOnlyCollection<Account>?> GetAll(Guid customerId, CancellationToken cancellationToken);
}
