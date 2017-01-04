using Narochno.Primitives.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Narochno.Primitives.Parsing
{
    public class DefaultParserLibrary : IParserLibrary
    {
        public static IParserLibrary Instance { get; set; } = new DefaultParserLibrary();

        public IDictionary<Type, IParser> Parsers { get; } = new Dictionary<Type, IParser>
        {
            { typeof(bool), new BoolParser() },
            { typeof(char), new CharParser() },
            { typeof(decimal), new DecimalParser() },
            { typeof(double), new DoubleParser() },
            { typeof(float), new FloatParser() },
            { typeof(Guid), new GuidParser() },
            { typeof(int), new IntParser() },
            { typeof(long), new LongParser() },
            { typeof(sbyte), new SByteParser() },
            { typeof(short), new ShortParser() },
            { typeof(uint), new UIntParser() },
            { typeof(ulong), new ULongParser() },
            { typeof(ushort), new UShortParser() }
        };

        public IParser GetParser(Type type)
        {
            if (Parsers.ContainsKey(type))
            {
                return Parsers[type];
            }

            // Enums need type information,
            // so each one gets a parser
            if (type.GetTypeInfo().IsEnum)
            {
                Parsers.Add(type, (IParser)Activator.CreateInstance(typeof(EnumParser<>).MakeGenericType(type)));
                return Parsers[type];
            }

            throw new ArgumentException($"Unable to find parser for {type.FullName}");
        }
    }
}
