using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Products.Application.Configuration;
using Poke.CloudSalesSystem.Products.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Products.Application.Model;
using System.Net;

namespace Poke.CloudSalesSystem.Products.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("Products API", Description = "Products API Endpoint")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            ISender sender,
            ILogger<ProductsController> logger)
        {
            _sender = Preconditions.CheckNotNull(sender, nameof(sender));
            _logger = Preconditions.CheckNotNull(logger, nameof(logger));
        }

        [HttpGet]
        [Route("/providers")]
        [OpenApiOperation("Get product providers configuration", "Get product provider configuration information")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductProvidersConfiguration))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public IActionResult GetProviderConfiguration(
            [FromServices] ProductProvidersConfiguration providerConfig,
            CancellationToken cancellationToken)
        {
            return Ok(providerConfig);
        }

        [HttpGet]
        [Route("{providerId:guid}")]
        [OpenApiOperation("Get all products", "Gets all products")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Product))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll([FromRoute] Guid providerId, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetProductsQuery(providerId), cancellationToken);
            return result.IsSuccess ?
                Ok(result.Value) :
                BadRequest(result.Errors);
        }
    }
}
