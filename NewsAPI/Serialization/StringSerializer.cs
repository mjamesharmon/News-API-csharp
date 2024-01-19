using System;
namespace NewsAPI.Serialization
{
    internal class StringSerializer : IQueryValueSerializer
    {
        public string Serialize(object? element)
        {
            var result = (element is null) ? string.Empty :
                element as string ?? string.Empty;
            return result.ToLowerInvariant();
        }
    }
}


