using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Cledev.OpenAI.V1.Contracts;

namespace Cledev.OpenAI.V1;

public interface IOpenAIService
{
    Task<RetrieveModelsResponse?> RetrieveModels();
    Task<RetrieveModelsResponse.RetrieveModelsResponseData?> RetrieveModel(string id);
    Task<CompletionCreateResponse?> CreateCompletion(CompletionCreateRequest request);
    Task<CompletionCreateResponse?> CreateCompletion(string prompt, CompletionsModel? model = null, int? maxTokens = null);
    Task<EditCreateResponse?> CreateEdit(EditCreateRequest request);
    Task<EditCreateResponse?> CreateEdit(string input, string instruction, EditsModel? model = null);
    Task<ImageCreateResponse?> CreateImage(ImageCreateRequest request);
    Task<ImageCreateResponse?> CreateImage(string prompt, int? numberOfImagesToGenerate = null, ImageSize? size = null, ImageResponseFormat? responseFormat = null);
}

public class OpenAIService : IOpenAIService
{
    private const string ApiVersion = "v1";

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

    public async Task<CompletionCreateResponse?> CreateCompletion(CompletionCreateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/completions", request);
        return await response.Content.ReadFromJsonAsync<CompletionCreateResponse?>();
    }

    public async Task<CompletionCreateResponse?> CreateCompletion(string prompt, CompletionsModel? model = null, int? maxTokens = null)
    {
        return await CreateCompletion(new CompletionCreateRequest
        {
            Model = (model ?? CompletionsModel.Ada).ToStringModel(),
            Prompt = prompt,
            MaxTokens = maxTokens ?? 16
        });
    }

    public async Task<EditCreateResponse?> CreateEdit(EditCreateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/edits", request);
        return await response.Content.ReadFromJsonAsync<EditCreateResponse?>();
    }

    public async Task<EditCreateResponse?> CreateEdit(string input, string instruction, EditsModel? model = null)
    {
        return await CreateEdit(new EditCreateRequest
        {
            Model = (model ?? EditsModel.TextDavinciEditV1).ToStringModel(),
            Input = input,
            Instruction = instruction
        });
    }

    public async Task<ImageCreateResponse?> CreateImage(ImageCreateRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/generations", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<ImageCreateResponse?>();
    }

    public async Task<ImageCreateResponse?> CreateImage(string prompt, int? numberOfImagesToGenerate = null, ImageSize? size = null, ImageResponseFormat? responseFormat = null)
    {
        return await CreateImage(new ImageCreateRequest
        {
            Prompt = prompt,
            NumberOfImagesToGenerate = numberOfImagesToGenerate ?? 1,
            ImageSize = (size ?? ImageSize.Size1024x1024).ToStringSize(),
            ResponseFormat = (responseFormat ?? ImageResponseFormat.Url).ToStringFormat()
        });
    }
}
