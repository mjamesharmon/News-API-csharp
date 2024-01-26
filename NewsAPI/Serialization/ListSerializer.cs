using System;
namespace NewsAPI.Serialization
{
	internal class ListSerializer<T> : IQueryValueSerializer
	{

        public string Serialize(object? element)
        {
            var list = GetEnumerable(element);
            return string.Join(",", list).ToLowerInvariant();
        }

        private IEnumerable<T> GetEnumerable(object? element) =>
            (element is null) ? Enumerable.Empty<T>() :
                element as List<T> ?? Enumerable.Empty<T>();
    }
}

