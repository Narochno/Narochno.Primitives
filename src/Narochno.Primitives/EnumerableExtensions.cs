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
            if (item != null)
            {
                yield return item;
            }
        }

        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
            this IEnumerable<TSource> source, int size)
        {
            TSource[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                {
                    bucket = new TSource[size];
                }

                bucket[count++] = item;
                if (count != size)
                {
                    continue;
                }

                yield return bucket;

                bucket = null;
                count = 0;
            }

            if (bucket != null && count > 0)
            {
                yield return bucket.Take(count);
            }
        }
    }
}