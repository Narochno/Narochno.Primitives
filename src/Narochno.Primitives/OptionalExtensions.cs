namespace Narochno.Primitives
{
    public static class OptionalExtensions
    {
        public static Optional<TType> Optional<TType>(this TType value)
        {
            return new Optional<TType>(value);
        }

        public static Optional<TType> Fallback<TType>(this Optional<TType> value, Optional<TType> fallback)
        {
            if (value.IsSet)
            {
                return value;
            }

            return fallback;
        }
    }
}
