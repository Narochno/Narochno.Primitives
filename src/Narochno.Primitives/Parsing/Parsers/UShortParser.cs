using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class UShortParser : Parser<ushort>
    {
        public override ushort Parse(string input) => ushort.Parse(input);

        public override ushort? TryParse(string input)
        {
            ushort result;
            if (ushort.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(ushort value)
        {
            return Convert.ToString(value);
        }
    }
}
