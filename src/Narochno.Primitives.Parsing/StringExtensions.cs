using System;

namespace Narochno.Primitives.Parsing
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert given string to Optional <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">The type to convert to</typeparam>
        /// <param name="input">The input string</param>
        /// <returns>The Optional <typeparamref name="TType"/> parsed from the string <paramref name="input"/></returns>
        public static Optional<TType> TryParse<TType>(this string input)
        {
            var result = DefaultParserLibrary.Instance.GetParser<TType>().TryParse(input);
            if (result.IsSet)
            {
                return (TType)result.Value;
            }
            return new Optional<TType>();
        }

        /// <summary>
        /// Convert given string to IOptional
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="type">The type to convert to</param>
        /// <returns>The IOptional parsed from the string <paramref name="input"/></returns>
        public static IOptional TryParse(this string input, Type type)
        {
            return DefaultParserLibrary.Instance.GetParser(type).TryParse(input);
        }

        /// <summary>
        /// Convert given string to type <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">The type to convert to</typeparam>
        /// <param name="input">The input string</param>
        /// <returns>The type <typeparamref name="TType"/> parsed from the string <paramref name="input"/></returns>
        public static TType Parse<TType>(this string input)
        {
            return (TType)DefaultParserLibrary.Instance.GetParser<TType>().Parse(input);
        }

        /// <summary>
        /// Convert given string to object
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="type">The type to convert to</param>
        /// <returns>The type parsed from the string <paramref name="input"/></returns>
        public static object Parse(this string input, Type type)
        {
            return DefaultParserLibrary.Instance.GetParser(type).Parse(input);
        }
    }
}
