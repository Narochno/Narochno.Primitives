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
        public static Optional<TType> ToOptional<TType>(this string input)
        {
            var result = DefaultParserLibrary.Instance.FindParser<TType>().TryParse(input);
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
        public static TType To<TType>(this string input) => (TType)DefaultParserLibrary.Instance.FindParser<TType>().Parse(input);
    }
}
