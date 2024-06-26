﻿namespace Narochno.Primitives.Parsing;

public static class ParserExtensions
{
    public static TType? TryParse<TType>(this IParser parser, string input)
        where TType : struct => (TType?)parser.TryParse(input);

    public static TType Parse<TType>(this IParser parser, string input)
        where TType : struct => (TType)parser.Parse(input);
}
