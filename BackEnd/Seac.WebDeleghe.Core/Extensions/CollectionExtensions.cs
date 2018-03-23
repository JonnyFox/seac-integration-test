using System.Collections.Generic;

namespace Seac.WebDeleghe.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T item)
        {
            foreach (var sourceItem in source)
            {
                yield return sourceItem;
            }

            yield return item;
        }
    }
}