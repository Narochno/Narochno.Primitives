using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class CharParser : Parser<char>
    {
        public override char Parse(string input) => char.Parse(input);

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
