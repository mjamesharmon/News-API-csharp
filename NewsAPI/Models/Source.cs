using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NewsAPI.Constants;

namespace NewsAPI.Models
{
    public sealed class Source : SourceId
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; } 
        [JsonPropertyName("url")]
        public string? Url { get; set; } 
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Categories? Category { get; set; } 
        [JsonPropertyName("language")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Languages? Language { get; set; }
        [JsonPropertyName("country")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Countries? Country { get; set; } 
    }
}
