using Poke.CloudSalesSystem.Common.Contracts.Products;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.Infrastructure.Services.Downstream;

public class ProductService : IProductService
{
    public Task<IReadOnlyCollection<Product>> GetProducts(Guid providerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, string>> GetProviders(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
