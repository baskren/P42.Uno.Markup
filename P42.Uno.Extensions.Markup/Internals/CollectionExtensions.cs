using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace P42.Uno.Extensions.Markup.Internals;

internal static class CollectionExtensions
{
    public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
    {
        collection.ForEach<T>(new Action<T>(((ICollection<T>)list).Add));
    }

    public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
    {
        foreach (T obj in list)
            action(obj);
    }

    public static void ModifiableForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        collection.ToList<T>().ForEach(action);
    }

    public static IEnumerable<T> SelectWithParent<TItem, T>(
      this IEnumerable<TItem> collection,
      Func<TItem, T> selector,
      object parent)
    {
        foreach (TItem obj in collection)
            yield return selector(obj);
    }
}
