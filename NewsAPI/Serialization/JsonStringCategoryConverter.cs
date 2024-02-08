using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
	public class JsonStringCategoryConverter : JsonConverter<Category>
	{
        public override Category Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString() ??
               throw new InvalidOperationException();
            return Category.FromName(value);
        }

        public override void Write(Utf8JsonWriter writer,
            Category value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}

