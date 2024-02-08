using System;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
	internal class CountryValueSerializer : IQueryValueSerializer
	{

        public string Serialize(object? element)
        {
            return (element is null) ?
             string.Empty : GetCountry((Country)element);
        }

        private string GetCountry(Country element) =>
            element.Name;
    }
}

