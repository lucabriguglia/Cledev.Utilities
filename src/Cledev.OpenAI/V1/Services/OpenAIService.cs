using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using Cledev.OpenAI.V1.Models;

namespace Cledev.OpenAI.V1.Services;

public interface IOpenAIService
{
    Task<RetrieveModelsResponse?> RetrieveModels();
    Task<RetrieveModelsResponse.RetrieveModelsResponseData?> RetrieveModel(string id);
    Task<CompletionCreateResponse?> CreateCompletion(string prompt, string? model = null, int? maxTokens = null);
}

public class OpenAIService : IOpenAIService
{
    private const string ApiVersion = "v1";
    private const string DefaultOpenAIModel = "ada";

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

    public async Task<RetrieveModelsResponse?> RetrieveModels()
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelsResponse?>($"/{ApiVersion}/models");
    }

    public async Task<RetrieveModelsResponse.RetrieveModelsResponseData?> RetrieveModel(string id)
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelsResponse.RetrieveModelsResponseData?>($"/{ApiVersion}/models/{id}");
    }

    public async Task<CompletionCreateResponse?> CreateCompletion(string prompt, string? model = null, int? maxTokens = null)
    {
        var request = new CompletionCreateRequest
        {
            Model = model ?? DefaultOpenAIModel,
            Prompt = prompt,
            MaxTokens = maxTokens ?? 16
        };

        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/completions", request);
        return await response.Content.ReadFromJsonAsync<CompletionCreateResponse?>();
    }
}
