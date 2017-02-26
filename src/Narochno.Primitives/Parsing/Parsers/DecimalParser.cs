using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class DecimalParser : Parser<decimal>
    {
        public override decimal Parse(string input) => decimal.Parse(input);

        public override decimal? TryParse(string input)
        {
            decimal result;
            if (decimal.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(decimal value)
        {
            return Convert.ToString(value);
        }
    }
}
