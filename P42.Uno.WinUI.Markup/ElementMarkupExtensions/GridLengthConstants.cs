namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class GridLengthConstants
{
    /// <summary>
    /// Auto GridLength
    /// </summary>
    public static GridLength Auto => GridLength.Auto;

    
    private static GridLength? DStar;
    /// <summary>
    /// Star GridLength
    /// </summary>
    public static GridLength Star => DStar ??= new(1.0, GridUnitType.Star);

    
    private static GridLength? DZero;
    /// <summary>
    /// Zero GridLength
    /// </summary>
    public static GridLength Zero => DZero ??= new(0.0);

}
