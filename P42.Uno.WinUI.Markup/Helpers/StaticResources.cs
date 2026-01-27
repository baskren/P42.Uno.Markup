using Windows.UI;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class StaticResources
{
    public static bool TryGetAppResourceAs<T>(string key, out T? value)
        => Application.Current.Resources.TryGetAs(key, out value);

    public static bool TryGetResourceAs<T>(this FrameworkElement d, string key, out T? value)
        => d.Resources.TryGetAs(key, out value);

    public static bool TryGetAs<T>(this ResourceDictionary resourceDictionary, string key, out T? value)
    {
        value = default;
        if (!resourceDictionary.TryGetValue(key, out var resourceValue))
            return false;
        
        if (typeof(T) == typeof(Brush) &&
            SolidBrushConverter.Instance.CanConvertFrom(resourceValue.GetType()) &&
            SolidBrushConverter.Instance.Convert(resourceValue, resourceValue.GetType(), null, null) is T tBrush
           )
        {
            value = tBrush;
            return true;
        }

        if (typeof(T) == typeof(Color) &&
            ColorConverter.Instance.CanConvertFrom(resourceValue.GetType()) &&
            ColorConverter.Instance.Convert(resourceValue, resourceValue.GetType(), null, null) is T tColor
           )
        {
            value = tColor;
            return true;
        }

        if (resourceValue is not T tValue)
            return false;

        value = tValue;
        return true;

    }

    public static FontFamily? SymbolThemeFontFamily
    {
        get
        {
            if (field != null)
                return field;
            if (!TryGetAppResourceAs<FontFamily>("SymbolThemeFontFamily", out var fontFamily))
                return null;
            return field = fontFamily;
        }
    }
}
