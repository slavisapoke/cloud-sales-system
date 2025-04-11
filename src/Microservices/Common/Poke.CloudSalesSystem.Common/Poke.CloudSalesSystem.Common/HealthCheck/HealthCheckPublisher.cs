using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Poke.CloudSalesSystem.Common.Constants;
using System.Text;
using System.Text.Json;

namespace Poke.CloudSalesSystem.Common.HealthCheck
{
    internal class HealthCheckPublisher(ILogger<HealthCheckPublisher> logger) : IHealthCheckPublisher
    {
        /// <summary>
        /// Publish custom healtchecks to some external diagnostics tool
        /// </summary>
        /// <param name="report"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {
            if (report.Status != HealthStatus.Healthy)
            {
                var details = GetHealthReportDetails(report);
                logger.LogWarning($"Service is not healthy: {LogPlaceholders.REPORT}", details);
            }

            cancellationToken.ThrowIfCancellationRequested();

            return Task.CompletedTask;
        }

        private string GetHealthReportDetails(HealthReport report)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(HeaderTemplate, report.TotalDuration));
            foreach (var (key, entry) in report.Entries)
            {
                stringBuilder.AppendLine(string.Format(ServiceTemplate,
                    key, entry.Status, entry.Description));

                foreach (var (entryDataKey, entryDataValue) in entry.Data)
                {
                    stringBuilder.AppendLine($"\t - {entryDataKey}: {JsonSerializer.Serialize(entryDataValue)}");
                }
            }

            return stringBuilder.ToString();
        }

        private readonly string HeaderTemplate = """
            HealthCheck report
             - Status: Degraded
             - TotalDuration: {0}
            """;
        private readonly string ServiceTemplate = """
             HealthCheckEntry: {0}
              - Status: {1}
              - Description: {2}
              - Data:
            """;
    }
}
