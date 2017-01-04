namespace Narochno.Primitives.Parsing
{
    public static class ParserLibraryExtensions
    {
        public static IParser GetParser<TType>(this IParserLibrary parserLibrary)
        {
            return parserLibrary.GetParser(typeof(TType));
        }
    }
}
