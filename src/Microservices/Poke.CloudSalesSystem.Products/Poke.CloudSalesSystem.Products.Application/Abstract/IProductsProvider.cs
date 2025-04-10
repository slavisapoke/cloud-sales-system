using Poke.CloudSalesSystem.Products.Application.Model;

namespace Poke.CloudSalesSystem.Products.Application.Abstract;

public interface IProductsProvider
{
    Task<IReadOnlyCollection<Product>> GetAllProducts(CancellationToken cancellationToken);
}
