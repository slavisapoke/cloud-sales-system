namespace Poke.CloudSalesSystem.Products.Application.Abstract;

public interface IProductProviderFactory
{
    IProductsProvider GetProvider(Guid providerId);
}
