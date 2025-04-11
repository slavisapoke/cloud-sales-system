using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Contracts.Products;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using System.Net;

namespace Poke.CloudSalesSystem.Gateway.API.Controllers;

[ApiController]
[Route("[controller]")]
[OpenApiTag("Products API", Description = "Products API Endpoint")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(
        IProductService productService,
        ILogger<ProductsController> logger)
    {
        _productService = Preconditions.CheckNotNull(productService, nameof(productService));
        _logger = Preconditions.CheckNotNull(logger, nameof(logger));
    }

    [HttpGet]
    [Route("/providers")]
    [OpenApiOperation("Get product providers", "Get registered product providers")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Dictionary<string, string>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> GetProviders(
        CancellationToken cancellationToken)
    {
        var result = await _productService.GetProviders(cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    [Route("{providerId:guid}")]
    [OpenApiOperation("Products for the given provider", "Gets all products for a given provider")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IReadOnlyCollection<Product>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll([FromRoute] Guid providerId, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProducts(providerId, cancellationToken);
        return Ok(result);
    }
}
