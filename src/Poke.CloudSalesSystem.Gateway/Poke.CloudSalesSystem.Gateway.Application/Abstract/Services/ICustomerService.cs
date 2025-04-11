using Poke.CloudSalesSystem.Common.Contracts.Customers;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

public interface ICustomerService
{
    Task<IReadOnlyCollection<Customer>?> GetAll(CancellationToken cancellationToken);
}
