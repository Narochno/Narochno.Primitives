using Narochno.Primitives.Parsing.Parsers;
using System;
using System.Collections.Generic;

namespace Narochno.Primitives.Parsing
{
    public static class StringExtensions
    {
        public static IDictionary<Type, IParser> Parsers { get; } = new Dictionary<Type, IParser>
        {
            { typeof(bool), new BoolParser() },
            { typeof(double), new DoubleParser() },
            { typeof(float), new FloatParser() },
            { typeof(Guid), new GuidParser() },
            { typeof(int), new IntParser() },
            { typeof(long), new LongParser() }
        };

        public static IParser FindParser<TType>()
        {
            try
            {
                return Parsers[typeof(TType)];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception($"Unable to find parser for {typeof(TType).Name}");
            }
        }

        /// <summary>
        /// Convert given string to Optional <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">The type to convert to</typeparam>
        /// <param name="input">The input string</param>
        /// <returns>The Optional <typeparamref name="TType"/> parsed from the string <paramref name="input"/></returns>
        public static Optional<TType> ToOptional<TType>(this string input)
        {
            var result = FindParser<TType>().TryParse(input);
            if (result.IsSet)
            {
                return (TType)result.Value;
            }

            return new Optional<TType>();
        }

        /// <summary>
        /// Convert given string to type <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">The type to convert to</typeparam>
        /// <param name="input">The input string</param>
        /// <returns>The type <typeparamref name="TType"/> parsed from the string <paramref name="input"/></returns>
        public static TType To<TType>(this string input) => (TType)FindParser<TType>().Parse(input);
    }
}
