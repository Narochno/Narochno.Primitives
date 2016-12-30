using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class EnumParser : Parser<Enum>
    {
        public Type Type { get; }
        public IList<Enum> Values { get; } = new List<Enum>();
        public IDictionary<Enum, string> EnumStrings { get; } = new Dictionary<Enum, string>();

        public EnumParser(Type type)
        {
            Type = type;
            foreach (var value in Enum.GetValues(type))
            {
                Values.Add((Enum)value);
            }

            // Cache this as it's expensive to fetch
            foreach (var value in Values)
            {
                foreach (var attribute in Type.GetField(Enum.GetName(Type, value))
                    .GetCustomAttributes<EnumMemberAttribute>())
                {
                    EnumStrings.Add(value, attribute.Value);
                }
            }
        }

        public override Enum Parse(string input)
        {
            // First try to get the fields with EnumMemberAttribute
            foreach (var value in Values)
            {
                if (EnumStrings.ContainsKey(value)
                    && EnumStrings[value].Equals(input))
                {
                    return value;
                }
            }

            // Fallback to the real Enum.Parse
            return (Enum)Enum.Parse(Type, input);
        }

        public override Optional<Enum> TryParse(string input)
        {
            // First try to get the fields with EnumMemberAttribute
            foreach (var value in Values)
            {
                if (EnumStrings.ContainsKey(value)
                    && EnumStrings[value].Equals(input))
                {
                    return value;
                }
            }

            // Fallback to a try parse (we can't use the
            // real TryParse here as it has type parameters)
            foreach (var value in Values)
            {
                if (Enum.GetName(Type, value).Equals(input))
                {
                    return value;
                }
            }

            return new Optional<Enum>();
        }
    }
}
