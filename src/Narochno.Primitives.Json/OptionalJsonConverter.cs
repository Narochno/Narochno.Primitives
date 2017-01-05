using System;
using Newtonsoft.Json;
using System.Reflection;

namespace Narochno.Primitives.Json
{
    public class OptionalJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IOptional).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var type = objectType.GenericTypeArguments[0];
            var optionalType = typeof(Optional<>).MakeGenericType(type);
            return Activator.CreateInstance(optionalType, Convert.ChangeType(reader.Value, type));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var optional = value as IOptional;
            serializer.Serialize(writer, optional.HasValue ? optional.Value : null);
        }
    }
}
