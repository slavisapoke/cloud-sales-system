using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Contracts.Customers;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Customers.Application.Handlers.Query.GetCustomers;
using System.Net;

namespace Poke.CloudSalesSystem.Customers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("Customers API", Description = "Customer API Endpoint")]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(
            ISender sender,
            ILogger<CustomersController> logger)
        {
            _sender = Preconditions.CheckNotNull(sender, nameof(sender));
            _logger = Preconditions.CheckNotNull(logger, nameof(logger));
        }

        [HttpGet]
        [OpenApiOperation("Get all customers","Gets all customers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Customer))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetCustomersQuery(), cancellationToken);
            return result.IsSuccess ?
                Ok(result.Value) :
                BadRequest(result.Errors);
        }
    }
}
