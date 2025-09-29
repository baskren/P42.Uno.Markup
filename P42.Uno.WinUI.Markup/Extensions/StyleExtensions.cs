
using Microsoft.UI.Xaml;

namespace P42.Uno.WinUI.Markup;



internal static class StyleExtensions
{
    public static bool TryGetSetterValue<T>(this Style style, DependencyProperty property, out T? value)
    {
        foreach (var baseSetter in style.Setters)
        {
            if (baseSetter is not Setter setter)
                continue;

            if (setter.Property == property)
            {
                value = (T?)setter.Value;
                return true;
            }

        }

        value = default;
        return false;
    }

    public static T? GetSetterValue<T>(this Style? style, DependencyProperty property, T? fallback = default)
    {
        if (style is null)
            return fallback;

        if (!TryGetSetterValue(style, property, out T? value))
            return value;

        return fallback;
    }
}
