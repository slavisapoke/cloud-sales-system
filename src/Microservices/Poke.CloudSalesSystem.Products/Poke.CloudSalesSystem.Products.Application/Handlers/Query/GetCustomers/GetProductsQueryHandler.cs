using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Common.Cache.Fusion.Extensions;
using Poke.CloudSalesSystem.Common.Contracts.Products;
using Poke.CloudSalesSystem.Products.Application.Abstract;
using Poke.CloudSalesSystem.Products.Application.Adapters;
using Poke.CloudSalesSystem.Products.Application.Constants;
using Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Products.Application.Helpers;
using ZiggyCreatures.Caching.Fusion;

namespace Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCase;

public class GetProductsQueryHandler(
    IFusionCache cache,
    ProductProviderFactory providerFactory) : IRequestHandler<GetProductsQuery, Result<IReadOnlyCollection<Product>>>
{
    public async Task<Result<IReadOnlyCollection<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await cache.GetOrCreateAsync<IReadOnlyCollection<Product>>(
            CacheKeys.GetProducts(request.ProviderId),
            (ctx, ct) => ActualGetProducts(request.ProviderId, cancellationToken),
            TimeSpan.FromMinutes(CacheExpirationTime.PRODUCT_EXPIRATION_IN_MINUTES));

        return Result.Ok(result);
    }

    private async Task<IReadOnlyCollection<Product>> ActualGetProducts(Guid providerId, CancellationToken cancellationToken)
    {
        IProductsProvider provider;
            
        provider = providerFactory.GetProvider(providerId);

        return await provider.GetAllProducts(cancellationToken);
    }

}
