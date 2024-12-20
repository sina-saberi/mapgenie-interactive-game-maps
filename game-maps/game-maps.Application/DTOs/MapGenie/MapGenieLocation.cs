using AutoMapper.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace game_maps.Application.DTOs.MapGenie
{
    public class FlexibleDecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // Try to parse the string to a decimal
                if (decimal.TryParse(reader.GetString(), out var result))
                {
                    return result;
                }
                throw new JsonException($"Unable to convert \"{reader.GetString()}\" to {nameof(Decimal)}.");
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetDecimal();
            }
            throw new JsonException($"Unexpected token parsing {nameof(Decimal)}. Token: {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
    public class MapGenieLocation
    {
        public int id { get; set; }
        public int map_id { get; set; }
        public int? region_id { get; set; }
        public int category_id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }

        [JsonPropertyName("latitude")]
        [JsonConverter(typeof(FlexibleDecimalConverter))]
        public decimal latitude { get; set; }

        [JsonPropertyName("longitude")]
        [JsonConverter(typeof(FlexibleDecimalConverter))]
        public decimal longitude { get; set; }
        // public string? features { get; set; }
        public string? ign_page_id { get; set; }
        public int[]? tags { get; set; }
        [JsonPropertyName("checked")]
        public bool? Checked { get; set; }

        public ICollection<MapGenieMedia>? media { get; set; }

    }
}
