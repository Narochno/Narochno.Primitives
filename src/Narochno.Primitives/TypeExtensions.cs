using System;
using System.Reflection;

namespace Narochno.Primitives;

public static class TypeExtensions
{
    public static bool IsNullable(this Type type) =>
        type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

    public static Type? GetNullableUnderlyingType(this Type type)
    {
        if (type.IsNullable())
        {
            return Nullable.GetUnderlyingType(type);
        }

        return type;
    }
}
