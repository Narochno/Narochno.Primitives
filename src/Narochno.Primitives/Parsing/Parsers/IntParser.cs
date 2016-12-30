namespace Narochno.Primitives.Parsing.Parsers
{
    public class IntParser : Parser<int>
    {
        public override int Parse(string input) => int.Parse(input);

        public override Optional<int> TryParse(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<int>();
        }
    }
}
