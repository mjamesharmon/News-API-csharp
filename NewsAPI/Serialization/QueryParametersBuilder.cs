using System;
using System.Reflection;
using System.Text;
using NewsAPI.Attributes;

namespace NewsAPI.Serialization
{
	internal class QueryParametersBuilder
	{
		private List<string> _values;

		public QueryParametersBuilder()
		{
			_values = new();
		}

		public QueryParametersBuilder AppendParameter<T>(T request,
			PropertyInfo property)
		{
			var attribute =
				property.GetCustomAttribute<RequestParameterAttribute>() ??
				null;

			if (attribute != null) {
				_values.Add(attribute.ApplyTo(request, property));
			}
	
			return this;
		}

        public override string ToString()
        {
			return string.Join("&", _values.Where(v =>
			string.IsNullOrWhiteSpace(v) == false));
        }
    }
}

