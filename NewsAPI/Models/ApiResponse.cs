using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewsAPI.Models
{
    internal class ApiResponse
    {
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Statuses Status { get; set; }
        [JsonPropertyName("code")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorCodes? Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        public List<Article> Articles { get; set; } = new();
        public int TotalResults { get; set; }
    }
}
