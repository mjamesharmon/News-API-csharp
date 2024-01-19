using System;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
    internal class EnumValueSerializer : IQueryValueSerializer
    {
        public string Serialize(object? element)
        {
            var result = (element is null) ? string.Empty :
               element.ToString() ?? string.Empty;
            return result.ToLowerInvariant();
        }
    }
}

