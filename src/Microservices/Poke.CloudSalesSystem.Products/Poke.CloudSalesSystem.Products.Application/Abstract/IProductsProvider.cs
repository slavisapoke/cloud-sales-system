using Poke.CloudSalesSystem.Common.Contracts.Products;

namespace Poke.CloudSalesSystem.Products.Application.Abstract;

public interface IProductsProvider
{
    Task<IReadOnlyCollection<Product>> GetAllProducts(CancellationToken cancellationToken);
}
