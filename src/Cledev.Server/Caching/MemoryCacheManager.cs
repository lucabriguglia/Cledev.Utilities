using Microsoft.Extensions.Caching.Memory;

namespace Cledev.Server.Caching;

public class MemoryCacheManager : ICacheManager
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheManager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task<T?> GetOrSetAsync<T>(string key, Func<Task<T?>> acquireAsync)
    {
        return GetOrSetAsync(key, 60, acquireAsync);
    }

    public async Task<T?> GetOrSetAsync<T>(string key, int cacheTime, Func<Task<T>> acquireAsync)
    {
        if (_memoryCache.TryGetValue(key, out T? data))
        {
            return data;
        }

        data = await acquireAsync();

        var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheTime));

        _memoryCache.Set(key, data, memoryCacheEntryOptions);

        return data;
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
}