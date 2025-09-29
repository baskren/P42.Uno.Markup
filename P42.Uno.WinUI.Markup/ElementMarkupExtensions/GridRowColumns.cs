using System;
using Microsoft.UI.Xaml;

namespace P42.Uno.Markup;

public static class GridRowsColumns
{
    public static GridLength Auto => new(1.0, GridUnitType.Auto);

    public static GridLength Star => new(1.0, GridUnitType.Star);

    public static GridLength Zero => new(0.0);

    /*
    public static int All<TEnum>() where TEnum : Enum
    {
        var values = Enum.GetValues(typeof(TEnum));
        var span = (int)values.GetValue(values.Length - 1) + 1;
        return span;
    }

    public static int Last<TEnum>() where TEnum : Enum
    {
        var values = Enum.GetValues(typeof(TEnum));
        var last = (int)values.GetValue(values.Length - 1);
        return last;
    }
    */
}
