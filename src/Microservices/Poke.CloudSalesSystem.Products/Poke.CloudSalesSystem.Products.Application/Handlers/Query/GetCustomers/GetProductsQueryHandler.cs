using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Products.Application.Adapters;
using Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Products.Application.Model;

namespace Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCase;

public class GetProductsQueryHandler(
    ProductProviderFactory providerFactory) : IRequestHandler<GetProductsQuery, Result<IReadOnlyCollection<Product>>>
{
    public async Task<Result<IReadOnlyCollection<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var provider = providerFactory.GetProvider(request.ProviderId);

        var results = await provider.GetAllProducts(cancellationToken);

        return Result.Ok(results);
    }
}
