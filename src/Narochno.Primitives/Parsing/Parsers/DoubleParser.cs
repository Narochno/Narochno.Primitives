using System;

namespace Narochno.Primitives.Parsing.Parsers;

public class DoubleParser : Parser<double>
{
    public override double Parse(string input) => double.Parse(input);

    public override double? TryParse(string input)
    {
        double result;
        if (double.TryParse(input, out result))
        {
            return result;
        }

        return null;
    }

    public override string ToString(double value) => Convert.ToString(value);
}
