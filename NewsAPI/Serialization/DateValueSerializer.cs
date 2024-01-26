using System;
using System.Xml.Linq;

namespace NewsAPI.Serialization
{
	internal class DateValueSerializer : IQueryValueSerializer
	{
        public string Serialize(object? element)
        {
            var result = (element is null) ? string.Empty :
             (element is DateTime dateTime) ?
             string.Format("{0:s}",dateTime) :
             string.Empty;
            return result.ToLowerInvariant();
        }
    }
}
