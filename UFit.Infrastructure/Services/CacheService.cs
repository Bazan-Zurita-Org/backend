using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using UFit.Application.Abstractions.Cache;

namespace UFit.Infrastructure.Services;
internal class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        var cacheValue = await _distributedCache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrEmpty(cacheValue))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<T>(cacheValue);
    }

    public Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default)
    {
        return _distributedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2),
            },
            cancellationToken);
    }
}
