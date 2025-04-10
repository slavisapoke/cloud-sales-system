using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Contracts.Accounts;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using System.Net;

namespace Poke.CloudSalesSystem.Gateway.API.Controllers;

[ApiController]
[Route("[controller]")]
[OpenApiTag("Accounts API", Description = "Accounts API Endpoint")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(
        IAccountService accountService,
        ILogger<AccountsController> logger)
    {
        _accountService = Preconditions.CheckNotNull(accountService, nameof(accountService));
        _logger = Preconditions.CheckNotNull(logger, nameof(logger));
    }

    [HttpGet]
    [Route("get-by-customer/{customerId:guid}")]
    [OpenApiOperation("Get accounts for customer", "Gets all accounts for customer")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Account>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromRoute] Guid customerId, CancellationToken cancellationToken)
    {
        var result = await _accountService.GetAll(customerId, cancellationToken);
        return Ok(result);
    }
}
