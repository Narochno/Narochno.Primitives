namespace Narochno.Primitives.Parsing.Parsers
{
    public class CharParser : Parser<char>
    {
        public override char Parse(string input) => char.Parse(input);

        public override Optional<char> TryParse(string input)
        {
            char result;
            if (char.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<char>();
        }
    }
}
