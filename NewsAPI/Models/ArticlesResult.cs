using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewsAPI.Models
{
    public class ArticlesResult : IResponse
    {
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Statuses? Status { get; set; }
        [JsonPropertyName("error")]
        public Error? Error { get; set; }
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }
        [JsonPropertyName("articles")]
        public List<Article>? Articles { get; set; }

        public static ArticlesResult Errored(string? message = null)
        {
            return new ArticlesResult
            {
                Status = Statuses.Error,
                Error = Error.DefaultError
            };
        }
    }
}
