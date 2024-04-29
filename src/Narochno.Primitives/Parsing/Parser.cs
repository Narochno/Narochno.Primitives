namespace Narochno.Primitives.Parsing
{
    /// <summary>
    /// The base class for all parsers
    /// </summary>
    /// <typeparam name="TType">The type this class will parse</typeparam>
    public abstract class Parser<TType> : IParser, IParser<TType>
        where TType : struct
    {
        object IParser.Parse(string input) => Parse(input);

        object? IParser.TryParse(string input) => TryParse(input);

        string IParser.ToString(object input) => ToString((TType)input);

        /// <summary>
        /// Convert from <paramref name="input"/> to the type <typeparamref name="TType"/>
        /// Should throw if invalid.
        /// </summary>
        /// <param name="input">The input string to convert from</param>
        /// <returns>A converted <typeparamref name="TType"/> object</returns>
        public abstract TType Parse(string input);

        /// <summary>
        /// Convert from <paramref name="input"/> to the type <typeparamref name="TType"/>
        /// Should not throw, instead return an unset <see cref="Optional{TType}" />.
        /// </summary>
        /// <param name="input">The input string to convert from</param>
        /// <returns>An <see cref="Optional{TType}" /></returns>
        public abstract TType? TryParse(string input);

        public abstract string ToString(TType value);
    }
}
