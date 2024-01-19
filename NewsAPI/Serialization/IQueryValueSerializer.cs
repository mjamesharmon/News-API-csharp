using System;
namespace NewsAPI.Serialization
{
	internal interface IQueryValueSerializer
	{
		public string Serialize(object? element);
	}
}

