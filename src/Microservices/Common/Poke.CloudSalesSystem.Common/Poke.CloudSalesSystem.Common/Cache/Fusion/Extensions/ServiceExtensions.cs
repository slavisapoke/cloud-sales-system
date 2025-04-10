using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poke.CloudSalesSystem.Common.Cache.Redis;
using Poke.CloudSalesSystem.Common.Helpers;
using ZiggyCreatures.Caching.Fusion.Serialization.SystemTextJson;
using ZiggyCreatures.Caching.Fusion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace Poke.CloudSalesSystem.Common.Cache.Fusion.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterFusionCache(this IServiceCollection services, IConfiguration configuration)
    {
        var cachingConfig = Preconditions.CheckNotNull(
            configuration.GetSection(nameof(CachingConfiguration)).Get<CachingConfiguration>(),
            nameof(CachingConfiguration));

        var redisConfig = Preconditions.CheckNotNull(
            configuration.GetSection(nameof(RedisConfiguration)).Get<RedisConfiguration>(),
            nameof(RedisConfiguration));

        services.AddFusionCache()
              .WithDefaultEntryOptions(new FusionCacheEntryOptions()
              {
                  Duration = TimeSpan.FromSeconds(cachingConfig!.MemoryCacheGlobalDurationInSeconds)
              })
              .WithOptions(options =>
              {
                  options.FactoryErrorsLogLevel = LogLevel.Error;
              })
                  .WithSerializer(
                      new FusionCacheSystemTextJsonSerializer()
                  )
              .WithDistributedCache(
                  new RedisCache(new RedisCacheOptions
                  {
                      Configuration = $"{redisConfig.Host}:{redisConfig.Port}",
                      InstanceName = cachingConfig.InstanceName
                  })
              );

        return services;
    }
}
