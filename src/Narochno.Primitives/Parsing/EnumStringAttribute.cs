using System;

namespace Narochno.Primitives.Parsing;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public class EnumStringAttribute : Attribute
{
    public EnumStringAttribute(string value) => Value = value;

    public string Value { get; set; }
}
