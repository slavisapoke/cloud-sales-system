using Poke.CloudSalesSystem.Common.Contracts.Accounts;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

/// <summary>
/// Account service
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Get all for the given customer
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<Account>?> GetAll(Guid customerId, CancellationToken cancellationToken);
}
