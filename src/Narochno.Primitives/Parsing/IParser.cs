namespace Narochno.Primitives.Parsing
{
    /// <summary>
    /// Do not implement this, it offers no type safety!
    /// Instead inherit from <see cref="Parser{TType}" />
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Convert from <paramref name="input"/> to the type <typeparamref name="TType"/>
        /// Should throw if invalid.
        /// </summary>
        /// <param name="input">The input string to convert from</param>
        /// <returns>A converted <typeparamref name="TType"/> object</returns>
        object TryParse(string input);

        /// <summary>
        /// Convert from <paramref name="input"/> to the type <typeparamref name="TType"/>
        /// Should not throw, instead return an unset <see cref="Optional{TType}" />.
        /// </summary>
        /// <param name="input">The input string to convert from</param>
        /// <returns>An <see cref="Optional{TType}" /></returns>
        object Parse(string input);

        string ToString(object input);
    }

    public interface IParser<TType>
        where TType : struct
    {
        /// <summary>
        /// Convert from <paramref name="input"/> to the type <typeparamref name="TType"/>
        /// Should throw if invalid.
        /// </summary>
        /// <param name="input">The input string to convert from</param>
        /// <returns>A converted <typeparamref name="TType"/> object</returns>
        TType? TryParse(string input);

        /// <summary>
        /// Convert from <paramref name="input"/> to the type <typeparamref name="TType"/>
        /// Should not throw, instead return an unset <see cref="Optional{TType}" />.
        /// </summary>
        /// <param name="input">The input string to convert from</param>
        /// <returns>An <see cref="Optional{TType}" /></returns>
        TType Parse(string input);

        string ToString(TType input);
    }
}
