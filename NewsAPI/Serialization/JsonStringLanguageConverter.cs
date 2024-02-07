using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewsAPI.Constants;

namespace NewsAPI.Serialization
{
	internal class JsonStringLanguageConverter : JsonConverter<Language>
	{
        public override Language Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString() ??
                throw new InvalidOperationException();
            return Language.FromName(value);
        }

        public override void Write(Utf8JsonWriter writer,
            Language value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}

