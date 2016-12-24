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
            return value.IsSet ? value.Value : fallback;
        }

        public static TType Unwrap<TType>(this Optional<TType> value)
        {
            return value.IsSet ? value.Value : default(TType);
        }

        public static TType? ToNullable<TType>(this Optional<TType> value) where TType : struct
        {
            return value.IsSet ? value.Value : (TType?)null;
        }
    }
}
