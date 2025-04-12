using Poke.CloudSalesSystem.Common.Contracts.Customers;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

/// <summary>
/// Customers service
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Gets all customers, no filtering
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<Customer>?> GetAll(CancellationToken cancellationToken);
}
