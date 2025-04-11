using Poke.CloudSalesSystem.Common.Contracts.Accounts;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class AccountService (IHttpClientFactory httpFactory) : IAccountService
{
    public async Task<IReadOnlyCollection<Account>?> GetAll(Guid customerId, CancellationToken cancellationToken)
    {
        var client = httpFactory.CreateClient(HttpNamedClient.ACCOUNT_SERVICE);

        return await client.GetAsyncThrowable<IReadOnlyCollection<Account>>(
            $"/accounts/get-by-customer/{customerId}", cancellationToken);
    }
}
