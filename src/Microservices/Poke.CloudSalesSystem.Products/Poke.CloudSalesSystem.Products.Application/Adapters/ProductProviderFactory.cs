using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Common.Contracts.Products;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Products.Application.Abstract;
using Poke.CloudSalesSystem.Products.Application.Configuration;

namespace Poke.CloudSalesSystem.Products.Application.Adapters
{
    public class ProductProviderFactory(IServiceProvider serviceProvider,
        ProductProvidersConfiguration providerRegister) : IProductProviderFactory
    {
        public IProductsProvider GetProvider(Guid providerId)
        { 
            if (providerId == providerRegister.CloudComputing)
                    return GetCloudComputing();

            if (providerId == providerRegister.SomeOtherProvider)
                return GetSomeOtherProvider();

            throw new NotSupportedException($"Invalid products provider Id: {providerId}");
        }

        private IProductsProvider GetCloudComputing()
        {
            var service = Preconditions.CheckNotNull(serviceProvider.GetService<ICloudComputingProvider>(), nameof(ICloudComputingProvider));
            var mapper = Preconditions.CheckNotNull(serviceProvider.GetService<IMapper>(), nameof(IMapper));
            return new CloudComputingAdapter(service, mapper);
        }

        private IProductsProvider GetSomeOtherProvider()
        {
            return new LocalProductsProvider();
        }

    }

    /// <summary>
    /// Any other provider, can be local database or whatever
    /// </summary>
    public class LocalProductsProvider : IProductsProvider
    {
        public Task<IReadOnlyCollection<Product>> GetAllProducts(CancellationToken cancellationToken) => 
            Task.FromResult< IReadOnlyCollection<Product>>([
                new Product{
                    Id = Guid.NewGuid(),
                    Name = "Azure SQL",
                    Description = "Migrate, modernize, and innovate with the modern SQL family of cloud database services.",
                    ProviderId = Guid.Parse("d0d8a489-7129-4125-b2dc-027e26936e6c")
                }]);
    }
}
