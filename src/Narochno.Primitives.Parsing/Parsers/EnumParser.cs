using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class EnumParser : Parser<Enum>
    {
        public Type EnumType { get; }
        public Array EnumValues { get; }

        public EnumParser(Type enumType)
        {
            EnumType = enumType;
            EnumValues = Enum.GetValues(EnumType);
        }

        public override Enum Parse(string input)
        {
            // First try to get the fields with EnumMemberAttribute
            foreach (var value in EnumValues)
            {
                foreach (var attribute in EnumType.GetField(Enum.GetName(EnumType, value))
                    .GetCustomAttributes<EnumMemberAttribute>())
                {
                    if (attribute.Value.Equals(input))
                    {
                        return (Enum)value;
                    }
                }
            }

            // Fallback to the real Enum.Parse
            return (Enum)Enum.Parse(EnumType, input);
        }

        public override Optional<Enum> TryParse(string input)
        {
            // First try to get the fields with EnumMemberAttribute
            foreach (var value in EnumValues)
            {
                foreach (var attribute in EnumType.GetField(Enum.GetName(EnumType, value))
                    .GetCustomAttributes<EnumMemberAttribute>())
                {
                    if (attribute.Value.Equals(input))
                    {
                        return (Enum)value;
                    }
                }
            }

            // Fallback to a try parse (we can't use the
            // real TryParse here as it has type parameters)
            foreach (var value in EnumValues)
            {
                if (Enum.GetName(EnumType, value).Equals(input))
                {
                    return (Enum)value;
                }
            }

            return new Optional<Enum>();
        }
    }
}
