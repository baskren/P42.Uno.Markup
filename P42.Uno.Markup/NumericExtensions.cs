using System;
using System.Collections.Generic;

namespace P42.Uno.Markup;

internal static class NumericExtensions
{
    public static T Clamp<T>(this T self, T min, T max) where T : IComparable
    {
        if (Comparer<T>.Default.Compare(max, min) < 0)
            return max;
        if (Comparer<T>.Default.Compare(self, min) < 0)
            return min;
        if (Comparer<T>.Default.Compare(self, max) > 0)
            return max;

        return self;
    }
}
