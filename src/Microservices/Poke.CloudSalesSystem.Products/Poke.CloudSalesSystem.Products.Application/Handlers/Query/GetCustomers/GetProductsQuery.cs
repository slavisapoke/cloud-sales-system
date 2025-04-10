using FluentResults;
using MediatR;
using Poke.CloudSalesSystem.Products.Application.Model;

namespace Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCustomers;

public record GetProductsQuery(Guid ProviderId) : IRequest<Result<IReadOnlyCollection<Product>>>;
