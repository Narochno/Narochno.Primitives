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
#if PORTABLE40
            return objectType.GetNullableUnderlyingType().IsEnum;
#else
            return objectType.GetNullableUnderlyingType().GetTypeInfo().IsEnum;
#endif
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
            var parser = parserLibrary.GetParser(value.GetType());
            writer.WriteValue(parser.ToString(value));        }
    }
}
