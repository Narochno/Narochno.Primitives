namespace Narochno.Primitives.Parsing.Parsers
{
    public class ShortParser : Parser<short>
    {
        public override short Parse(string input) => short.Parse(input);

        public override Optional<short> TryParse(string input)
        {
            short result;
            if (short.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<short>();
        }
    }
}
