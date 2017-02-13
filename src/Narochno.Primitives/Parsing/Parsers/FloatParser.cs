using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class FloatParser : Parser<float>
    {
        public override float Parse(string input) => float.Parse(input);

        public override float? TryParse(string input)
        {
            float result;
            if (float.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }

        public override string ToString(float value)
        {
            return Convert.ToString(value);
        }
    }
}
