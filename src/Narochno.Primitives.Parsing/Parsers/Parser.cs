namespace Narochno.Primitives.Parsing.Parsers
{
    /// <summary>
    /// The base class for all <typeparamref name="TType"/> parsers
    /// </summary>
    /// <typeparam name="TType">The type this class will convert to</typeparam>
    public abstract class Parser<TType> : IParser
    {
        object IParser.Parse(string input) => Parse(input);
        IOptional IParser.TryParse(string input) => TryParse(input);

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
        public abstract Optional<TType> TryParse(string input);
    }
}