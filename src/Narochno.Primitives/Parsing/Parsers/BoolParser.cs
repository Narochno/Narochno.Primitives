namespace Narochno.Primitives.Parsing.Parsers
{
    public class BoolParser : Parser<bool>
    {
        public override bool Parse(string input) => bool.Parse(input);

        public override Optional<bool> TryParse(string input)
        {
            bool result;
            if (bool.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<bool>();
        }
    }
}
