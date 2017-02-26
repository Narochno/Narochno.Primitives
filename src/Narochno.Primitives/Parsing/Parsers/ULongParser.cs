using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class ULongParser : Parser<ulong>
    {
        public override ulong Parse(string input) => ulong.Parse(input);

        public override ulong? TryParse(string input)
        {
            ulong result;
            if (ulong.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(ulong value)
        {
            return Convert.ToString(value);
        }
    }
}
