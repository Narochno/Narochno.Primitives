using System;

namespace Narochno.Primitives
{
    public struct Optional<TValue>
    {
        private readonly TValue value;

        public Optional(TValue value)
        {
            IsSet = true;
            this.value = value;
        }

        public TValue Value
        {
            get
            {
                if (NotSet)
                {
                    throw new InvalidOperationException($"Optional<{typeof(TValue).Name}> is not set");
                }

                return value;
            }
        }

        public bool NotSet => !IsSet;
        public bool IsSet { get; }
        public override string ToString() => value?.ToString() ?? "Not Set";
        public override int GetHashCode() => value?.GetHashCode() ?? 0;
        public static implicit operator Optional<TValue>(TValue value) => new Optional<TValue>(value);
        public static implicit operator TValue(Optional<TValue> optional) => optional.Value;

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
