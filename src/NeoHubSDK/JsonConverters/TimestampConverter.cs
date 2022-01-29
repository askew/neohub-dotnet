using System.Text.Json;
using System.Text.Json.Serialization;

namespace Heatmiser.NeoHubSDK.JsonConverters
{
    /// <summary>
    /// JSON converter that will map UNIX timestamp values that may be stored as numbers or strings.
    /// Nulls are processed as <see cref="DateTime.MinValue"/>.
    /// </summary>
    internal class TimestampConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime unixEpoc = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <inheritdoc/>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return DateTime.MinValue;
            }
            if (reader.TokenType == JsonTokenType.Number)
            {
                double unixtime = reader.GetDouble();

                return unixEpoc.AddSeconds(unixtime);
            }
            string? value = string.Empty;
            if (reader.TokenType == JsonTokenType.String)
            {
                value = reader.GetString();
                if (DateTime.TryParse(value, out DateTime time))
                {
                    return time;
                }
            }

            throw new JsonException($"Cannot convert \"{value}\" to DataTime.");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((value - unixEpoc).TotalSeconds);
        }
    }
}
