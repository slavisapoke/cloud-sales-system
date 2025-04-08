using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Helpers;

namespace Poke.CloudSalesSystem.Licenses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("License API", Description = "License API Endpoint")]
    public class LicensesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<LicensesController> _logger;

        public LicensesController(
            ISender sender,
            ILogger<LicensesController> logger)
        {
            _sender = Preconditions.CheckNotNull(sender, nameof(sender));
            _logger = Preconditions.CheckNotNull(logger, nameof(logger));
        }
    }
}
