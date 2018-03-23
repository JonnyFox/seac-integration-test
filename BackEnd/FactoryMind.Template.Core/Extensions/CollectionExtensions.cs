using System.Collections.Generic;

namespace FactoryMind.Template.Core.Extensions
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