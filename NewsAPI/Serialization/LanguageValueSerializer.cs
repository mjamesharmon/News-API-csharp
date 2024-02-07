using System;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
	internal class LanguageValueSerializer : IQueryValueSerializer
	{
        public string Serialize(object? element)
        {
            return (element is null) ?
                string.Empty : GetLanguage((Language)element);
        }

        private string GetLanguage(Language element) =>
          element.Name;

    }
}

