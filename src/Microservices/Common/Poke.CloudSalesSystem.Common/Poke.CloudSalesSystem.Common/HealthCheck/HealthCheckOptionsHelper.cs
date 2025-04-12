using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Poke.CloudSalesSystem.Common.HealthCheck
{
    public static class HealthCheckOptionsHelper
    {
        /// <summary>
        /// Creates healthcheck options with custom response writer
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static HealthCheckOptions GetHealthCheckOptions(Func<HealthCheckRegistration, bool> predicate = null)
        {
            return new HealthCheckOptions
            {
                Predicate = predicate,
                AllowCachingResponses = false,
                ResponseWriter = HealthCheckWriter.WriteResponseAsync,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            };
        }
    }
}
