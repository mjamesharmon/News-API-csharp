using System;
using System.Reflection;
using NewsAPI.Serialization;

namespace NewsAPI.Attributes
{
	internal class RequestParameterAttribute : Attribute
	{
		private readonly string _name;
		private readonly Type _serializer;

		public RequestParameterAttribute(string name, Type? serializer = null)
		{
			_name = name;
			_serializer = serializer ?? typeof(StringSerializer);
		}

		public string ApplyTo<T>(T item, PropertyInfo pi)
		{
			var serializer = _serializer.Assembly.
				CreateInstance(_serializer.FullName ?? string.Empty)
				as IQueryValueSerializer ??
				throw new InvalidOperationException(
					"Serializer is not of type IQueryValueSerializer");
			string value = serializer.Serialize(pi.GetValue(item));

			return (string.IsNullOrWhiteSpace(value)) ? string.Empty :
				$"{_name}={value}";
			
		}
	}
}

