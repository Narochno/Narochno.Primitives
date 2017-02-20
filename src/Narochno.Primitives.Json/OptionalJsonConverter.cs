using System;
using Newtonsoft.Json;
using System.Reflection;

namespace Narochno.Primitives.Json
{
    public class OptionalJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
#if PORTABLE40
            return typeof(IOptional).IsAssignableFrom(objectType);
#else
            return typeof(IOptional).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
#endif
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
#if PORTABLE40
            var type = objectType.GetGenericArguments()[0];
#else
            var type = objectType.GetTypeInfo().GenericTypeArguments[0];
#endif
            var optionalType = typeof(Optional<>).MakeGenericType(type);
            return Activator.CreateInstance(optionalType, Convert.ChangeType(reader.Value, type, null));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var optional = value as IOptional;
            serializer.Serialize(writer, optional.HasValue ? optional.Value : null);
        }
    }
}
