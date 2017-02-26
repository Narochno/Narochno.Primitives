using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class LongParser : Parser<long>
    {
        public override long Parse(string input) => long.Parse(input);

        public override long? TryParse(string input)
        {
            long result;
            if (long.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(long value)
        {
            return Convert.ToString(value);
        }
    }
}
