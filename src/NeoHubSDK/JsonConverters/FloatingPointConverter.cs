using System.Text.Json;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK.JsonConverters
{
    /// <summary>
    /// JSON converter that will map floating point values that may be stored as numbers or strings.
    /// Nulls are processed as zero.
    /// </summary>
    internal class FloatingPointConverter : JsonConverter<float>
    {
        /// <inheritdoc/>
        public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return 0f;
            }
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetSingle();
            }
            string? value = string.Empty;
            if (reader.TokenType == JsonTokenType.String)
            {
                value = reader.GetString();
                if (float.TryParse(value, out float f))
                {
                    return f;
                }
            }

            throw new JsonException($"Cannot convert \"{value}\" to number.");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
