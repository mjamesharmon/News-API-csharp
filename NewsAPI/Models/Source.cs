using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NewsAPI.Constants;
using NewsAPI.Serialization;

namespace NewsAPI.Models
{
    public sealed class Source 
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; } 
        [JsonPropertyName("url")]
        public string? Url { get; set; } 
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringCategoryConverter))]
        public Category? Category { get; set; } 
        [JsonPropertyName("language")]
        [JsonConverter(typeof(JsonStringLanguageConverter))]
        public Language? Language { get; set; }
        [JsonPropertyName("country")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Countries? Country { get; set; } 
    }
}
