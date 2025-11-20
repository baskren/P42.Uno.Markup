
namespace P42.Uno.WinUI.Markup;



public static partial class StyleExtensions
{
    public static bool TryGetSetterValue<T>(this Style style, DependencyProperty property, out T? value)
    {
        foreach (var baseSetter in style.Setters)
        {
            if (baseSetter is not Setter setter)
                continue;

            if (setter.Property != property)
                continue;

            value = (T?)setter.Value;
            return true;
        }

        value = default;
        return false;
    }

    public static T? GetSetterValue<T>(this Style? style, DependencyProperty property, T? fallback = default)
    {
        if (style is null)
            return fallback;

        return !TryGetSetterValue(style, property, out T? value) 
            ? value 
                : fallback;
    }
}
