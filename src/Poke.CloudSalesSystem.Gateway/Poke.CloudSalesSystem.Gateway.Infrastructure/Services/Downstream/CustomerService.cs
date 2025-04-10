using Poke.CloudSalesSystem.Common.Contracts.Customers;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class CustomerService : ICustomerService
{
    public Task<IReadOnlyCollection<Customer>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
