using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Contracts.Customers;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using System.Net;

namespace Poke.CloudSalesSystem.Gateway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("Customers API", Description = "Customer API Endpoint")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(
            ILogger<CustomersController> logger)
        {
            _logger = Preconditions.CheckNotNull(logger, nameof(logger));
        }

        [HttpGet]
        [OpenApiOperation("Get all customers","Gets all customers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Customer))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(
            [FromServices] ICustomerService customerService,
            CancellationToken cancellationToken)
        {
            var response = await customerService.GetAll(cancellationToken);
            return Ok(response);
        }
    }
}
