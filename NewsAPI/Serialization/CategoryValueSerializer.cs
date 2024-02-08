using System;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
	public class CategoryValueSerializer : IQueryValueSerializer
	{
        public string Serialize(object? element)
        {
            return (element is null) ?
                string.Empty : GetCategory((Category)element);
        }

        private string GetCategory(Category element) =>
            element.Name;
       
    }
}

