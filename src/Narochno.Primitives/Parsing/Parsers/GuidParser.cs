using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class GuidParser : Parser<Guid>
    {
        public override Guid Parse(string input) => Guid.Parse(input);

        public override Guid? TryParse(string input)
        {
            Guid result;
            if (Guid.TryParse(input, out result))
            {
                return result;
            }

            return null;
        }
    }
}
