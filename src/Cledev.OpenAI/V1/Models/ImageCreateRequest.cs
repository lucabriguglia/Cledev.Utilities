using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Models;

public class ImageCreateRequest
{
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    [JsonPropertyName("n")]
    public int? N { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("response_format")]
    public string? ResponseFormat { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }
}