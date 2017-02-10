﻿using System;

namespace Narochno.Primitives.Parsing
{
    public static class Convert<TType>
        where TType : struct
    {

        private static IParser<TType> parser = (IParser<TType>)DefaultParserLibrary.Instance.GetParser(typeof(TType));

        /// <summary>
        /// Convert given string to Nullable <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">The type to convert to</typeparam>
        /// <param name="input">The input string</param>
        /// <returns>The Nullable <typeparamref name="TType"/> parsed from the string <paramref name="input"/></returns>
        public static TType? TryParse(string input)
        {
            return parser.TryParse(input);
        }

        /// <summary>
        /// Convert given string to type <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">The type to convert to</typeparam>
        /// <param name="input">The input string</param>
        /// <returns>The type <typeparamref name="TType"/> parsed from the string <paramref name="input"/></returns>
        public static TType Parse(string input)
        {
            return parser.Parse(input);
        }

        /// <summary>
        /// Convert given string to object
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="type">The type to convert to</param>
        /// <returns>The type parsed from the string <paramref name="input"/></returns>
        public static string ToString(TType type)
        {
            return parser.ToString(type);
        }
    }
}