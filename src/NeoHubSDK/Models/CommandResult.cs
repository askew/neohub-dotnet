using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK.Models
{
    public record CommandResult
    {
        [JsonPropertyName("result")]
        public string? Result { get; init; }
    }
}
