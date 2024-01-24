using System;
using System.Text.Json.Serialization;

namespace NewsAPI.Models
{
	public abstract class SourceId
	{
        [JsonPropertyName("id")]
        public string? Id { get; set; } 
        [JsonPropertyName("name")]
        public string? Name { get; set; } 
    }
}

