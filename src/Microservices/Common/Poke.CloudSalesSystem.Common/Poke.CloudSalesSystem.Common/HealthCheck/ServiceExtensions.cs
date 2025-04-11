using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Poke.CloudSalesSystem.Common.HealthCheck
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureHealthCheckPublisher(this IServiceCollection services)
        {
            services.AddSingleton<IHealthCheckPublisher, HealthCheckPublisher>();
            return services;
        }
    }
}
