﻿using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Models;

public class EditCreateRequest
{
    [JsonPropertyName("model")]
    public required string Model { get; set; }

    [JsonPropertyName("input")]
    public string? Input { get; set; }

    [JsonPropertyName("instruction")]
    public required string Instruction { get; set; }

    [JsonPropertyName("temperature")]
    public int? Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public int? TopP { get; set; }

    [JsonPropertyName("n")]
    public int? N { get; set; }
}
