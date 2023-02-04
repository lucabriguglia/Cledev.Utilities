using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts;

public class EditCreateResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("choices")]
    public List<EditCreateResponseChoice> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public EditCreateResponseUsage Usage { get; set; } = null!;

    public class EditCreateResponseChoice
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;

        [JsonPropertyName("index")]
        public int Index { get; set; }
    }

    public class EditCreateResponseUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int EditTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
