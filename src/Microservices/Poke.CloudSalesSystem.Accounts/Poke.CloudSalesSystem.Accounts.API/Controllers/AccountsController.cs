using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Accounts.Application.Handlers.Query.GetCustomers;
using Poke.CloudSalesSystem.Common.Contracts.Accounts;
using Poke.CloudSalesSystem.Common.Helpers;
using System.Net;

namespace Poke.CloudSalesSystem.Accounts.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("Accounts API", Description = "Accounts API Endpoint")]
    public class AccountsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(
            ISender sender,
            ILogger<AccountsController> logger)
        {
            _sender = Preconditions.CheckNotNull(sender, nameof(sender));
            _logger = Preconditions.CheckNotNull(logger, nameof(logger));
        }

        [HttpGet]
        [Route("get-by-customer/{customerId:guid}")]
        [OpenApiOperation("Get accounts for customer","Gets all accounts for customer")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Account>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute] Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetAccountsQuery(customerId), cancellationToken);
            return result.IsSuccess ?
                Ok(result.Value) :
                BadRequest(result.Errors);
        }
    }
}
