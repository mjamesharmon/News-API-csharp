using System;
namespace NewsAPI.Serialization
{
    internal class IntegerValueSerializer : IQueryValueSerializer
    {
        public string Serialize(object? element)
        {
            var result = (element is null) ? string.Empty :
                (element is int elementAsInt) ?
                 elementAsInt.ToString() : 
                 string.Empty;
            return result.ToLowerInvariant();
        }
    }
}