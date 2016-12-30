namespace Narochno.Primitives.Parsing.Parsers
{
    public class SByteParser : Parser<sbyte>
    {
        public override sbyte Parse(string input) => sbyte.Parse(input);

        public override Optional<sbyte> TryParse(string input)
        {
            sbyte result;
            if (sbyte.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<sbyte>();
        }
    }
}
