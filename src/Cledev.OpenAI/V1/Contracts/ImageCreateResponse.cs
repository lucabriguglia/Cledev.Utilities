using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts;

public class ImageCreateResponse
{
    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("data")]
    public List<ImageCreateResponseData> Data { get; set; } = new();

    public class ImageCreateResponseData
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("b64_json")] 
        public string? B64Json { get; set; }
    }
}
