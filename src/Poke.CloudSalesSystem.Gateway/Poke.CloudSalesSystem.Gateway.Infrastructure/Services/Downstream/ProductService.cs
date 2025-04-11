using Poke.CloudSalesSystem.Common.Contracts.Products;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class ProductService (IHttpClientFactory httpFactory) : IProductService
{
    public async Task<IReadOnlyCollection<Product>?> GetProducts(
        Guid providerId, CancellationToken cancellationToken)
    {
        var client = httpFactory.CreateClient(HttpNamedClient.PRODUCT_SERVICE);

        return await client.GetAsyncThrowable<IReadOnlyCollection<Product>>(
            $"products/{providerId}", cancellationToken);
    }

    public async Task<Dictionary<string, string>?> GetProviders(CancellationToken cancellationToken)
    {
        var client = httpFactory.CreateClient(HttpNamedClient.PRODUCT_SERVICE);

        return await client.GetAsyncThrowable<Dictionary<string, string>>($"providers", cancellationToken);
    }
}
