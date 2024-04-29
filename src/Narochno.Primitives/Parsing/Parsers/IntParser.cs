using System;

namespace Narochno.Primitives.Parsing.Parsers;

public class IntParser : Parser<int>
{
    public override int Parse(string input) => int.Parse(input);

    public override int? TryParse(string input)
    {
        int result;
        if (int.TryParse(input, out result))
        {
            return result;
        }

        return null;
    }

    public override string ToString(int value) => Convert.ToString(value);
}
