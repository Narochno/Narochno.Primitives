using System;

namespace Narochno.Primitives.Parsing.Parsers;

public class UIntParser : Parser<uint>
{
    public override uint Parse(string input) => uint.Parse(input);

    public override uint? TryParse(string input)
    {
        uint result;
        if (uint.TryParse(input, out result))
        {
            return result;
        }

        return null;
    }

    public override string ToString(uint value) => Convert.ToString(value);
}
