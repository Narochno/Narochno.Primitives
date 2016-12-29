using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class EnumParser<TEnumType> : Parser<Enum>
    {
        public Type EnumType { get; }
        public Array EnumValues { get; }

        public EnumParser()
        {
            EnumType = typeof(TEnumType);
            EnumValues = Enum.GetValues(EnumType);
        }

        public override Enum Parse(string input)
        {
            foreach (var enumValue in EnumValues)
            {
                foreach (var attribute in EnumType.GetField(enumValue.ToString()).GetCustomAttributes<EnumMemberAttribute>())
                {
                    if (attribute.Value.Equals(input))
                    {
                        return (Enum)enumValue;
                    }
                }
            }

            return (Enum)Enum.Parse(EnumType, input);
        }

        public override Optional<Enum> TryParse(string input)
        {
            foreach (var enumValue in EnumValues)
            {
                foreach (var attribute in EnumType.GetField(enumValue.ToString()).GetCustomAttributes<EnumMemberAttribute>())
                {
                    if (attribute.Value.Equals(input))
                    {
                        return (Enum)enumValue;
                    }
                }
            }

            foreach (var enumValue in EnumValues)
            {
                if (Enum.GetName(EnumType, enumValue).Equals(input))
                {
                    return (Enum)enumValue;
                }
            }

            return new Optional<Enum>();
        }
    }
}
