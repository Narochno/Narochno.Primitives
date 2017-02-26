﻿namespace Narochno.Primitives.Parsing
{
    public static class ParserLibraryExtensions
    {
        public static IParser<TType> GetParser<TType>(this IParserLibrary parserLibrary)
            where TType : struct
        {
            return (IParser<TType>)parserLibrary.GetParser(typeof(TType));
        }
    }
}
