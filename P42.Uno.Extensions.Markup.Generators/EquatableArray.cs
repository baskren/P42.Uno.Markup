using System;
using System.Collections.Immutable;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

internal static class EquatableArray
{
    public static EquatableArray<T> AsEquatableArray<T>(this ImmutableArray<T> array) where T : IEquatable<T>
    {
        return new EquatableArray<T>(array);
    }
}
