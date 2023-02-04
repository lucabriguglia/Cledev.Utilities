using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cledev.OpenAI.Services;

public interface IOpenAIService
{
    Task<CompletionCreateResponse?> CreateCompletion(string prompt);
}

public class OpenAIService : IOpenAIService
{
    private readonly HttpClient _httpClient;

    public OpenAIService(HttpClient httpClient, IOptions<OpenAISettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.openai.com/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.Value.ApiKey}");
        if (string.IsNullOrEmpty(settings.Value.Organization) is false)
        {
            _httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", $"{settings.Value.Organization}");
        }
    }

    public async Task<CompletionCreateResponse?> CreateCompletion(string prompt)
    {
        var request = new CompletionCreateRequest
        {
            Model = Models.Ada,
            Prompt = prompt
        };

        var response = await _httpClient.PostAsJsonAsync("/v1/completions", request);
        return await response.Content.ReadFromJsonAsync<CompletionCreateResponse?>();
    }
}
