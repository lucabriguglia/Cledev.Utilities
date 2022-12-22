﻿using System.Net.Http.Json;

namespace Cledev.Client.Services;

public class ApiServiceAnonymous
{
    private readonly HttpClient _httpClient;

    public ApiServiceAnonymous(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetFromJsonAsync<T>(string requestUri)
    {
        return await _httpClient.GetFromJsonAsync<T>(requestUri);
    }
}