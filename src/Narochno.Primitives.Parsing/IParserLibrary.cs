using Narochno.Primitives.Parsing.Parsers;

namespace Narochno.Primitives.Parsing
{
    public interface IParserLibrary
    {
        IParser FindParser<TType>();
    }
}