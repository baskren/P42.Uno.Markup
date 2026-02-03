namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class GridLengthExtensions
{
    public static global::Microsoft.UI.Xaml.GridLength Auto => new(global::Microsoft.UI.Xaml.GridLength.Auto.Value, GridUnitType.Auto);

    public static global::Microsoft.UI.Xaml.GridLength Star(double portion = 1.0) => new(portion, GridUnitType.Star);

    public static global::Microsoft.UI.Xaml.GridLength Pixels(double pixels) => new(pixels, GridUnitType.Pixel);

    public static global::Microsoft.UI.Xaml.GridLength Zero => new(0.0);

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
