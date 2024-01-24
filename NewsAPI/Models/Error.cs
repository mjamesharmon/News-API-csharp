using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewsAPI.Models
{
    public class Error
    {

        [JsonPropertyName("code")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorCodes Code { get; set; } 

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        internal static Error DefaultError => new Error
        {
            Code = ErrorCodes.UnknownError,
            Message = "An unknown error has occured."
        };
    }
}
