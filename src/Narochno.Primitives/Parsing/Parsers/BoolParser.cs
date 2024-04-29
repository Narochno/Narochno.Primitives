using System;

namespace Narochno.Primitives.Parsing.Parsers;

public class BoolParser : Parser<bool>
{
    public override bool Parse(string input) => bool.Parse(input);

    public override bool? TryParse(string input)
    {
        bool result;
        if (bool.TryParse(input, out result))
        {
            return result;
        }

        return null;
    }

    public override string ToString(bool value) => Convert.ToString(value);
}
