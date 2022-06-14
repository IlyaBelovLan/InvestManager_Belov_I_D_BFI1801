namespace InvestManager.Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionsExtensions
    {
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> collection) => collection == null || !collection.Any();
    }
}