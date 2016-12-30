namespace Narochno.Primitives.Parsing.Parsers
{
    public class DoubleParser : Parser<double>
    {
        public override double Parse(string input) => double.Parse(input);

        public override Optional<double> TryParse(string input)
        {
            double result;
            if (double.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<double>();
        }
    }
}
