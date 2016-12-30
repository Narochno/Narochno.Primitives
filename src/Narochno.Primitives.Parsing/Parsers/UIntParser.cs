namespace Narochno.Primitives.Parsing.Parsers
{
    public class UIntParser : Parser<uint>
    {
        public override uint Parse(string input) => uint.Parse(input);

        public override Optional<uint> TryParse(string input)
        {
            uint result;
            if (uint.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<uint>();
        }
    }
}
