using System.Collections.Generic;

namespace Narochno.Primitives;

public static class DictionaryExtensions
{
    public static TValue? GetValue<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary,
        TKey key
    )
        where TValue : struct
    {
        if (!dictionary.TryGetValue(key, out var value))
        {
            return null;
        }

        return value;
    }
}
