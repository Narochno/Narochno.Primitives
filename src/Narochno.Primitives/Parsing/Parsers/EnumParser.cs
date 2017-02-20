﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class EnumParser<T>: Parser<T>
        where T : struct 
    {
        public Type Type { get; }
        public List<T> Values { get; } = new List<T>();
        public IDictionary<string, T> EnumStrings { get; } = new Dictionary<string, T>();
        public IDictionary<T, string> EnumStringsReverse { get; } = new Dictionary<T, string>();

        public EnumParser()
        {
            Type = typeof(T);
            foreach (var value in Enum.GetValues(Type))
            {
                Values.Add((T)value);
            }

            // Cache this as it's expensive to fetch
            foreach (var value in Values)
            {
                foreach (var attribute in Type.GetField(Enum.GetName(Type, value))
                    .GetCustomAttributes(false).OfType<EnumStringAttribute>())
                {
                    EnumStrings.Add(attribute.Value, (T)value);
                    EnumStringsReverse.Add((T)value, attribute.Value);
                }
            }
        }

        public override T Parse(string input)
        {
            // First try to get the fields with EnumMemberAttribute
            if (input != null && EnumStrings.ContainsKey(input))
            {
                return EnumStrings[input];
            }

            // Fallback to the real Enum.Parse
            return (T)Enum.Parse(Type, input, true);
        }

        public override T? TryParse(string input)
        {
            // First try to get the fields with EnumMemberAttribute
            if (input != null && EnumStrings.ContainsKey(input))
            {
                return EnumStrings[input];
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

            return null;
        }

        public override string ToString(T value)
        {
            string s;
            if (EnumStringsReverse.TryGetValue(value, out s))
            {
                return s;
            }
            return value.ToString();
        }
    }
}
