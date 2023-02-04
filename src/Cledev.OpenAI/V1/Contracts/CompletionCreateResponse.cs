using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts;

public class CompletionCreateResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("choices")]
    public List<CompletionCreateResponseChoice> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public CompletionCreateResponseUsage Usage { get; set; } = null!;

    public class CompletionCreateResponseChoice
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("logprobs")]
        public string? Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; } = null!;
    }

    public class CompletionCreateResponseUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
