using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

namespace Poke.CloudSalesSystem.Common.HealthCheck;

public sealed class HealthCheckWriter
{
    /// <summary>
    /// Health check writter with some dummy decision logic 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="report"></param>
    /// <returns></returns>
    public static async Task WriteResponseAsync(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";

        var statusAggregate = report.Status;

        if (report.Status != HealthStatus.Healthy)
        {
            var unhealthyCount = report.Entries.Count(s => s.Value.Status == HealthStatus.Unhealthy);
            var degradedCount = report.Entries.Count(s => s.Value.Status == HealthStatus.Degraded);
            var total = report.Entries.Count();

            if(degradedCount / (float)total >= .25)
            { 
                statusAggregate = HealthStatus.Degraded;
            }
            if(unhealthyCount / (float)total  > .25)
            {
                statusAggregate = HealthStatus.Unhealthy;
            }
        }
        
        var healthCheckResult = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description,
                duration = entry.Value.Duration.TotalMilliseconds,
                exception = entry.Value.Exception?.Message
            })
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(healthCheckResult));
    }
}
