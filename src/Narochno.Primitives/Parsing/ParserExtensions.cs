namespace Narochno.Primitives.Parsing
{
    public static class ParserExtensions
    {
        public static Optional<TType> TryParse<TType>(this IParser parser, string input)
        {
            var result = parser.TryParse(input);
            if (result.IsSet)
            {
                return (TType)result.Value;
            }

            return new Optional<TType>();
        }

        public static TType Parse<TType>(this IParser parser, string input)
        {
            return (TType)parser.Parse(input);
        }
    }
}
