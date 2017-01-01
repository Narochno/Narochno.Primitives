using System;

namespace Narochno.Primitives.Parsing
{
    public interface IParserLibrary
    {
        IParser GetParser(Type type);
    }
}