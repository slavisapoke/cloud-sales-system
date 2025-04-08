using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Poke.CloudSalesSystem.Common.Helpers;

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
    }
}
