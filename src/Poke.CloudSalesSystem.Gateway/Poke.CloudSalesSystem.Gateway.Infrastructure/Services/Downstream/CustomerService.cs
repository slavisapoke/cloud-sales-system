using Poke.CloudSalesSystem.Common.Contracts.Customers;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class CustomerService(IHttpClientFactory httpFactory) : ICustomerService
{
    public async Task<IReadOnlyCollection<Customer>?> GetAll(CancellationToken cancellationToken)
    {
        var client = httpFactory.CreateClient(HttpNamedClient.CUSTOMER_SERVICE);

        return await client.GetAsyncThrowable<IReadOnlyCollection<Customer>>($"customers", cancellationToken);
    }
}
