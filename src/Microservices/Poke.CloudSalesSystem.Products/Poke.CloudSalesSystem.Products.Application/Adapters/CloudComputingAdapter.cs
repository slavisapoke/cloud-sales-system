using AutoMapper;
using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract;
using Poke.CloudSalesSystem.Products.Application.Abstract;
using Poke.CloudSalesSystem.Products.Application.Model;

namespace Poke.CloudSalesSystem.Products.Application.Adapters
{
    public class CloudComputingAdapter(
        ICloudComputingProvider ccpService,
        IMapper mapper) : IProductsProvider
    {
        public async Task<IReadOnlyCollection<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            var ccpProducts = await ccpService.GetServices(cancellationToken);

            return ccpProducts.IsFailed ? [] : mapper.Map<IReadOnlyCollection<Product>>(ccpProducts.Value);
        }
    }
}
