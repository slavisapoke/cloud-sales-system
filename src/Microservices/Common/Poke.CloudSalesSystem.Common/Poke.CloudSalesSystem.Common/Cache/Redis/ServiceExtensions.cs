using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Poke.CloudSalesSystem.Common.Helpers;

namespace Poke.CloudSalesSystem.Common.Cache.Redis;

public static class ServiceExtensions
{
    public static IHealthChecksBuilder AddCacheHealthCheck(
        this IHealthChecksBuilder healthCheckBuilder, RedisConfiguration redisConfig)
    {
        Preconditions.CheckNotNull(redisConfig, nameof(redisConfig));

        healthCheckBuilder
             .AddRedis(
                redisConnectionString: $"{redisConfig.Host}:{redisConfig.Port}",
                name: "Cache - Redis",
                failureStatus: HealthStatus.Degraded);

        return healthCheckBuilder;
    }
}
