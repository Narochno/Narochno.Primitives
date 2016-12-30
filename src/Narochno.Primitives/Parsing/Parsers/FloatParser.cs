namespace Narochno.Primitives.Parsing.Parsers
{
    public class FloatParser : Parser<float>
    {
        public override float Parse(string input) => float.Parse(input);

        public override Optional<float> TryParse(string input)
        {
            float result;
            if (float.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<float>();
        }
    }
}
