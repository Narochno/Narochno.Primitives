using System;
using Newtonsoft.Json;
using System.Reflection;
using Narochno.Primitives.Parsing;

namespace Narochno.Primitives.Json
{
    public class EnumStringConverter : JsonConverter
    {
        private IParserLibrary parserLibrary = DefaultParserLibrary.Instance;

        public EnumStringConverter()
        {
        }

        public EnumStringConverter(IParserLibrary parserLibrary)
        {
            this.parserLibrary = parserLibrary;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetNullableUnderlyingType().GetTypeInfo().IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType.IsNullable() && reader.Value == null)
            {
                return existingValue;
            }

            return parserLibrary.GetParser(objectType.GetNullableUnderlyingType()).Parse(reader.Value?.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
