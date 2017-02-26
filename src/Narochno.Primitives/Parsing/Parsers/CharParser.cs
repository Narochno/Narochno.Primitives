using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class CharParser : Parser<char>
    {
        public override char Parse(string input)
        {
            var c = TryParse(input);
            if (c.HasValue)
            {
                return c.Value;
            }
            throw new InvalidOperationException("Cannot parse: " + input);
        }

        public override char? TryParse(string input)
        {
            char result;
            if (char.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(char value)
        {
            return Convert.ToString(value);
        }
    }
}
