using System;
using System.Reflection;
using System.Text;
using NewsAPI.Attributes;
using NewsAPI.Models;

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
			var applicator = GetApplicator<T>(property);

			_values.Add(applicator(request,property));

			return this;
		}

		private Func<T, PropertyInfo, string> GetApplicator<T>(PropertyInfo property) {
			RequestParameterAttribute? attribute =
				property.GetCustomAttribute<RequestParameterAttribute>();

			return (attribute == null) ? (d,p) => string.Empty :
				attribute.ApplyTo;
		}

        public override string ToString()
        {
			return string.Join("&", _values.Where(v =>
				string.IsNullOrWhiteSpace(v) == false));
        }
    }
}

