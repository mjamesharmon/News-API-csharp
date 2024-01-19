using System.Text.Json.Serialization;

namespace NewsAPI.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Categories
    {
        Business,
        Entertainment,
        Health,
        Science,
        Sports,
        Technology
    }
}
