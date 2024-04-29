using System;
using System.Reflection;
using Narochno.Primitives.Parsing;
using Newtonsoft.Json;

namespace Narochno.Primitives.Json;

public class EnumStringConverter : JsonConverter
{
    private IParserLibrary parserLibrary = DefaultParserLibrary.Instance;

    public EnumStringConverter() { }

    public EnumStringConverter(IParserLibrary parserLibrary) => this.parserLibrary = parserLibrary;

    public override bool CanConvert(Type objectType) =>
        objectType.GetNullableUnderlyingType().GetTypeInfo().IsEnum;

    public override object? ReadJson(
        JsonReader reader,
        Type objectType,
        object? existingValue,
        JsonSerializer serializer
    )
    {
        if (objectType.IsNullable() && reader.Value == null)
        {
            return existingValue;
        }

        return parserLibrary
            .GetParser(objectType.GetNullableUnderlyingType().NotNull())
            .Parse(reader.Value.NotNull().ToString());
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var parser = parserLibrary.GetParser(value.NotNull().GetType().NotNull());
        writer.WriteValue(parser.ToString(value.NotNull()));
    }
}
