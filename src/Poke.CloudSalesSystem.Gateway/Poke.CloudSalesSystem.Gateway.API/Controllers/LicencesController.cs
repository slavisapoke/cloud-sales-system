using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Request;
using Poke.CloudSalesSystem.Common.Contracts.Licences.Response;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;
using System.Net;

namespace Poke.CloudSalesSystem.Gateway.API.Controllers;

[ApiController]
[Route("[controller]")]
[OpenApiTag("Licence API", Description = "Licence API Endpoint")]
public class LicencesController : ControllerBase
{
    private readonly ILicenceService _licenceService;
    private readonly ILogger<LicencesController> _logger;

    public LicencesController(
        ILicenceService licenceService,
        ILogger<LicencesController> logger)
    {
        _licenceService = Preconditions.CheckNotNull(licenceService, nameof(licenceService));
        _logger = Preconditions.CheckNotNull(logger, nameof(logger));
    }

    [HttpPost]
    [Route("subscription/cancel")]
    [OpenApiOperation("Cancel subscription", "Cancels subscription - cancels all related licences")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CancelSubscriptionResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> CancelSubscription([FromBody] CancelSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var result = await _licenceService.CancelSubscription(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("extend")]
    [OpenApiOperation("Extend licence", "Extends licence validity")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ExtendLicenceResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> ExtendLicense([FromBody] ExtendLicenceRequest extendCommand, CancellationToken cancellationToken)
    {
        var result = await _licenceService.ExtendLicense(extendCommand, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("order")]
    [OpenApiOperation("Order service licences", "Orders service licences")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrderLicencesResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> OrderLicenses([FromBody] OrderLicencesRequest orderCommand, CancellationToken cancellationToken)
    {
        var result = await _licenceService.OrderLicenses(orderCommand, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("subscription/update")]
    [OpenApiOperation("Update subscription quantity", "Updates subscription quanity")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UpdateLicenceQuantityResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateLicenseQuantity([FromBody] UpdateLicenceQuantityRequest updateCommand, CancellationToken cancellationToken)
    {
        var result = await _licenceService.UpdateLicenseQuantity(updateCommand, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    [Route("{accountId:guid}")]
    [OpenApiOperation("Get account's licences info", "Gets all licences for the given account")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GetAccountLicencesResponse))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromRoute] Guid accountId, CancellationToken cancellationToken)
    {
        var result = await _licenceService.GetAccountLicenses(accountId, cancellationToken);
        return Ok(result);
    }
}
