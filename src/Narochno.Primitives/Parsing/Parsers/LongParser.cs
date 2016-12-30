namespace Narochno.Primitives.Parsing.Parsers
{
    public class LongParser : Parser<long>
    {
        public override long Parse(string input) => long.Parse(input);

        public override Optional<long> TryParse(string input)
        {
            long result;
            if (long.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<long>();
        }
    }
}
