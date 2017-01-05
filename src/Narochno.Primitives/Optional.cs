using System;

namespace Narochno.Primitives
{
    public struct Optional<TValue> : IOptional
        where TValue : class
    {
        private readonly TValue value;

        public Optional(TValue value)
        {
            HasValue = value != null;
            this.value = value;
        }

        public TValue Value
        {
            get
            {
                if (HasNoValue)
                {
                    throw new InvalidOperationException($"Optional<{typeof(TValue).Name}> is not set");
                }

                return value;
            }
        }

        public bool HasNoValue => !HasValue;
        public bool HasValue { get; }
        object IOptional.Value => Value;

        public override string ToString() => value?.ToString() ?? "Not Set";
        public override int GetHashCode() => value?.GetHashCode() ?? 0;
        public static implicit operator Optional<TValue>(TValue value) => new Optional<TValue>(value);

        public override bool Equals(object obj)
        {
            if ((obj is TValue))
            {
                return Equals(value, obj);
            }

            if (!(obj is Optional<TValue>))
            {
                return false;
            }

            var other = (Optional<TValue>)obj;
            return Equals(value, other.value);
        }
    }
}
