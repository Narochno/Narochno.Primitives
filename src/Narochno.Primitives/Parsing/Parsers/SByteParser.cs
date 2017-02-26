using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class SByteParser : Parser<sbyte>
    {
        public override sbyte Parse(string input) => sbyte.Parse(input);

        public override sbyte? TryParse(string input)
        {
            sbyte result;
            if (sbyte.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(sbyte value)
        {
            return Convert.ToString(value);
        }
    }
}
