using System;
using System.Collections.Generic;
using System.Reflection;
using Narochno.Primitives.Parsing.Parsers;

namespace Narochno.Primitives.Parsing
{
    public class DefaultParserLibrary : IParserLibrary
    {
        private static object lockObject = new();
        public static IParserLibrary Instance { get; } = new DefaultParserLibrary();

        public IDictionary<Type, IParser> Parsers { get; } =
            new Dictionary<Type, IParser>
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
            if (Parsers.TryGetValue(type, out var parser1))
            {
                return parser1;
            }

            lock (lockObject)
            {
                if (Parsers.TryGetValue(type, value: out var parser))
                {
                    return parser;
                }

                // Enums need type information,
                // so each one gets a parser
                if (type.GetTypeInfo().IsEnum)
                {
                    Parsers.Add(
                        type,
                        (IParser)
                            Activator
                                .CreateInstance(typeof(EnumParser<>).MakeGenericType(type))
                                .NotNull()
                    );
                    return Parsers[type];
                }

                throw new ArgumentException($"Unable to find parser for {type.FullName}");
            }
        }
    }
}
