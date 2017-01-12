using System.Collections.Generic;
using System.Linq;

namespace Narochno.Primitives
{
    public static class EnumerableExtensions
    {
        public static Optional<T> SingleOrOptional<T>(this IEnumerable<T> items)
            where T : class
        {
            return new Optional<T>(items.SingleOrDefault());
        }

        public static Optional<T> FirstOrOptional<T>(this IEnumerable<T> items)
            where T : class
        {
            return new Optional<T>(items.FirstOrDefault());
        }

        public static IEnumerable<T> AsEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}