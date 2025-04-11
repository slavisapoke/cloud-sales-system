using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Contracts;
using Poke.CloudSalesSystem.Common.Helpers;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.CancelSubscription;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.ExtendLicence;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.OrderService;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Command.UpdateLicenceQuantity;
using Poke.CloudSalesSystem.Licences.Application.Handlers.Query.GetAccountLicences;
using System.Net;

namespace Poke.CloudSalesSystem.Licences.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("Licence API", Description = "Licence API Endpoint")]
    public class LicencesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<LicencesController> _logger;

        public LicencesController(
            ISender sender,
            ILogger<LicencesController> logger)
        {
            _sender = Preconditions.CheckNotNull(sender, nameof(sender));
            _logger = Preconditions.CheckNotNull(logger, nameof(logger));
        }

        [HttpPost]
        [Route("subscription/cancel")]
        [OpenApiOperation("Cancel subscription", "Cancels subscription - cancels all related licences")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CancelSubscriptionCommandResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> CancelSubscription([FromBody] CancelSubscriptionCommand cancelCommand, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(cancelCommand, cancellationToken);
            return Ok(result.IsSuccess ?
                ApiResponse<CancelSubscriptionCommandResponse>.Success(result.Value) :
                ApiResponse<CancelSubscriptionCommandResponse>.Fail(result.Errors.Select(e => e.Message).ToList()));
        }

        [HttpPost]
        [Route("extend")]
        [OpenApiOperation("Extend licence", "Extends licence validity")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ExtendLicenceCommandResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> ExtendLicence([FromBody] ExtendLicenceCommand extendCommand, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(extendCommand, cancellationToken);
            return Ok(result.IsSuccess ?
                ApiResponse<ExtendLicenceCommandResponse>.Success(result.Value) :
                ApiResponse<ExtendLicenceCommandResponse>.Fail(result.Errors.Select(e => e.Message).ToList()));
        }

        [HttpPost]
        [Route("order")]
        [OpenApiOperation("Order service licences", "Orders service licences")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<OrderLicencesCommandResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> OrderLicences([FromBody] OrderLicencesCommand orderCommand, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(orderCommand, cancellationToken);
            return Ok(result.IsSuccess ?
                ApiResponse<OrderLicencesCommandResponse>.Success(result.Value) :
                ApiResponse<OrderLicencesCommandResponse>.Fail(result.Errors.Select(e => e.Message).ToList()));
        }

        [HttpPost]
        [Route("subscription/update")]
        [OpenApiOperation("Update subscription quantity", "Updates subscription quanity")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UpdateLicenceQuantityCommandResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateLicenceQuantity([FromBody] UpdateLicenceQuantityCommand updateCommand, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(updateCommand, cancellationToken);
            return Ok(result.IsSuccess ?
                ApiResponse<UpdateLicenceQuantityCommandResponse>.Success(result.Value) :
                ApiResponse<UpdateLicenceQuantityCommandResponse>.Fail(result.Errors.Select(e => e.Message).ToList()));
        }

        [HttpGet]
        [Route("{accountId:guid}")]
        [OpenApiOperation("Get account's licences info", "Gets all licences for the given account")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<GetAccountLicencesQueryResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute] Guid accountId, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetAccountLicencesQuery(accountId), cancellationToken);
            return Ok(result.IsSuccess ?
                ApiResponse<GetAccountLicencesQueryResponse>.Success(result.Value) :
                ApiResponse<GetAccountLicencesQueryResponse>.Fail(result.Errors.Select(e => e.Message).ToList()));
        }
    }
}
