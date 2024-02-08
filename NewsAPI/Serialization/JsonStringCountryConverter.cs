using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
	public class JsonStringCountryConverter : JsonConverter<Country>
	{
	
        public override Country Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString() ??
               throw new InvalidOperationException();
            return Country.FromName(value);
        }

        public override void Write(Utf8JsonWriter writer,
            Country value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);

        }
    }
}

