using System;

namespace Narochno.Primitives.Parsing.Parsers
{
    public class GuidParser : Parser<Guid>
    {
        public override Guid Parse(string input) => Guid.Parse(input);

        public override Optional<Guid> TryParse(string input)
        {
            Guid result;
            if (Guid.TryParse(input, out result))
            {
                return result;
            }

            return new Optional<Guid>();
        }
    }
}
