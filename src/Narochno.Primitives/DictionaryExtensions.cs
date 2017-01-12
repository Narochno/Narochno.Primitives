using System.Collections.Generic;

namespace Narochno.Primitives
{
    public static class DictionaryExtensions
    {
        public static Optional<TValue> GetObject<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {
            if (!dictionary.ContainsKey(key))
            {
                return new Optional<TValue>();
            }

            return dictionary[key];
        }

        public static TValue? GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : struct
        {
            if (!dictionary.ContainsKey(key))
            {
                return null;
            }

            return dictionary[key];
        }
    }
}
