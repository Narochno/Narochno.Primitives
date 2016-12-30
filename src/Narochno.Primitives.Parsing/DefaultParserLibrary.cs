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
            { typeof(double), new DoubleParser() },
            { typeof(float), new FloatParser() },
            { typeof(Guid), new GuidParser() },
            { typeof(int), new IntParser() },
            { typeof(long), new LongParser() }
        };

        public IParser GetParser<TType>()
        {
            var type = typeof(TType);

            if (Parsers.ContainsKey(type))
            {
                return Parsers[type];
            }

            // Enums have to be handled specially
            if (type.GetTypeInfo().IsEnum)
            {
                return new EnumParser<TType>();
            }

            throw new Exception($"Unable to find parser for {typeof(TType).Name}");
        }
    }
}
