﻿namespace Narochno.Primitives.Parsing.Parsers
{
    public class DecimalParser : Parser<decimal>
    {
        public override decimal Parse(string input) => decimal.Parse(input);

        public override Optional<decimal> TryParse(string input)
        {
            decimal result;
            if (decimal.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<decimal>();
        }
    }
}