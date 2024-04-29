using System;

namespace Narochno.Primitives
{
    public static class HexExtensions
    {
        public static string ToHexString(this byte[] ba)
        {
            string hex = BitConverter.ToString(ba).ToLowerInvariant();
            return hex.Replace("-", "");
        }
    }
}
