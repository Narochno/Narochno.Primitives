namespace Narochno.Primitives.Parsing.Parsers
{
    public class ULongParser : Parser<ulong>
    {
        public override ulong Parse(string input) => ulong.Parse(input);

        public override Optional<ulong> TryParse(string input)
        {
            ulong result;
            if (ulong.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<ulong>();
        }
    }
}
