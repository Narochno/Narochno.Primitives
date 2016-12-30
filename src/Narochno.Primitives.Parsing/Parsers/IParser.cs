namespace Narochno.Primitives.Parsing.Parsers
{
    /// <summary>
    /// Do not implement this, it offers no type safety!
    /// Instead inherit from <see cref="Parser{TType}" />
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Do not implement this, it offers no type safety!
        /// Instead inherit from <see cref="Parser{TType}" />
        /// </summary>
        IOptional TryParse(string input);

        /// <summary>
        /// Do not implement this, it offers no type safety!
        /// Instead inherit from <see cref="Parser{TType}" />
        /// </summary>
        object Parse(string input);
    }
}
