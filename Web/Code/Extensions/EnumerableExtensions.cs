﻿namespace Web.Code.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static IEnumerable<TSource>? NullIfEmpty<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Any() ? source : null;
    }
}
