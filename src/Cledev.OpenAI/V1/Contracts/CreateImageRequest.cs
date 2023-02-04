using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts;

public class CreateImageRequest
{
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    [JsonPropertyName("n")]
    public required int? NumberOfImagesToGenerate { get; set; }

    [JsonPropertyName("size")]
    public required string? ImageSize { get; set; }

    [JsonPropertyName("response_format")]
    public required string? ResponseFormat { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }
}
