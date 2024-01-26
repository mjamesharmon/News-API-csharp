using System;
using System.Reflection;
using System.Web;
using NewsAPI.Serialization;

namespace NewsAPI.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	internal class RequestParameterAttribute : Attribute
	{
		private readonly string _name;
		private readonly Type _serializer;

		public RequestParameterAttribute(string name, Type? serializer = null)
		{
			_name = name;
			_serializer = serializer ?? TypeOfDefaultSerializer;
		}

		public string ApplyTo<T>(T item, PropertyInfo pi)
		{
			var serializer = Activator.CreateInstance(_serializer) 
				as IQueryValueSerializer ?? DefaultSerializer;
			string value = serializer.Serialize(pi.GetValue(item));

			return (string.IsNullOrWhiteSpace(value)) ? string.Empty :
				GetRequestParamterFor(value);
		}

		private string GetRequestParamterFor(string value) =>
			$"{_name}={Encode(value)}";

		private IQueryValueSerializer DefaultSerializer =>
			new StringSerializer();

		private Type TypeOfDefaultSerializer
		 => typeof(StringSerializer);

		private string Encode(string value) =>
			HttpUtility.UrlEncode(value);
	}
}

