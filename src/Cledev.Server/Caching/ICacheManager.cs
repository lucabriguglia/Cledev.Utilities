﻿namespace Cledev.Server.Caching;

public interface ICacheManager
{
    Task<T?> GetOrSetAsync<T>(string key, Func<Task<T?>> acquireAsync);

    Task<T?> GetOrSetAsync<T>(string key, int cacheTime, Func<Task<T>> acquireAsync);

    void Remove(string key);
}