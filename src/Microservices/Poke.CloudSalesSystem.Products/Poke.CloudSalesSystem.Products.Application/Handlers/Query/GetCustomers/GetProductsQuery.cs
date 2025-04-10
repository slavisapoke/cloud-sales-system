using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Common.Contracts.Products;

namespace Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCustomers;

public record GetProductsQuery(Guid ProviderId) : IRequest<Result<IReadOnlyCollection<Product>>>;
