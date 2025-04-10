using ZiggyCreatures.Caching.Fusion;

namespace Poke.CloudSalesSystem.Common.Cache.Fusion.Extensions
{
    public static class CacheExtensions
    {
        private static readonly TimeSpan DefaultFailSafeDuration = TimeSpan.FromHours(1);
        private static readonly TimeSpan JitteringDefault = TimeSpan.FromMilliseconds(10);

        /// <summary>
        /// Gets or creates item with given factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="cacheKey">Cache key</param>
        /// <param name="factory">Value factory</param>
        /// <param name="expirationTime">Cache expiration time</param>
        /// <param name="failSafeDuration">Failsafe duration - defaults to 1h</param>
        /// <param name="jitteringOption">Jittering - defaults to 10 miliseconds</param>
        /// <returns></returns>
        public async static Task<T> GetOrCreateAsync<T>(this IFusionCache cache,
            string cacheKey,
            Func<FusionCacheFactoryExecutionContext<T>, CancellationToken, Task<T>> factory,
            TimeSpan expirationTime,
            TimeSpan? failSafeDuration = null,
            TimeSpan? jitteringOption = null)
        {
            var result = await cache.GetOrSetAsync(cacheKey,
                factory,
                options => options
                .SetDistributedCacheDuration(expirationTime)
                .SetDistributedCacheFailSafeOptions(failSafeDuration ?? DefaultFailSafeDuration)
                  .SetJittering(jitteringOption ?? JitteringDefault));

            return result;
        }
    }
}
