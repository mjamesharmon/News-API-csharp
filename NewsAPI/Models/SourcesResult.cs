using System;
using System.Text.Json.Serialization;
using NewsAPI.Constants;

namespace NewsAPI.Models
{
	public sealed class SourcesResult : IResponse
	{

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Statuses? Status { get; set; } 
        [JsonPropertyName("error")]
        public Error? Error { get; set; }
        [JsonPropertyName("sources")]
        public IEnumerable<Source>? Sources { get; set; }

        public static SourcesResult Errored(string? message = null)
        {          
            return new SourcesResult
            {
                Status = Statuses.Error,
                Error = Error.DefaultError
            };
        }
    }
}

