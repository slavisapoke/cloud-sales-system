using Poke.CloudSalesSystem.Common.Contracts.Products;

namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

public interface IProductService
{
    Task<Dictionary<string, string>> GetProviders(CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Product>> GetProducts(Guid providerId, CancellationToken cancellationToken);
}
