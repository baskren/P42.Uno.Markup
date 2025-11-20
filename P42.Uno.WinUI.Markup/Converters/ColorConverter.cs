using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Windows.UI;
using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

public class ColorConverter : TypeConverter, IValueConverter
{
    private static ColorConverter? _instance;
    public static ColorConverter Instance => _instance ??= new ColorConverter();

    private ColorConverter()
    {
    }

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        if (sourceType == typeof(SolidColorBrush))
            return true;

        if (sourceType == typeof(Color))
            return true;

        if (sourceType == typeof(string))
            return true;

        if (sourceType == typeof(int))
            return true;

        return sourceType == typeof(uint) || base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
    {
        if (destinationType == typeof(Color))
            return true;
        if (destinationType == typeof(SolidColorBrush))
            return true;
        if (destinationType == typeof(string))
            return true;
        if (destinationType == typeof(int))
            return true;
        if (destinationType == typeof(uint))
            return true;
        
        return base.CanConvertTo(context, destinationType);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        try
        {
            return Convert(value, value.GetType(), null, null);
        }
        catch (Exception)
        {
            return base.ConvertFrom(context, culture, value);
        }
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        try
        {
            return ConvertBack(value, destinationType, null, null);
        }
        catch (Exception)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    
    public object? Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        return value switch
        {
            Color => value,
            SolidColorBrush brush => brush.Color,
            string hexText => ColorExtensions.ColorFromString(hexText),
            uint uintValue => ColorExtensions.ColorFromUint(uintValue),
            int intValue and >= 0 => ColorExtensions.ColorFromUint((uint)intValue),
            _ => default(Color)
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        value ??= default(Color);

        if (value is not Color color)
            throw new NotImplementedException($"Cannot convert back type [{value.GetType()}] to a [{targetType}]");

        if (targetType == typeof(Color))
            return color;

        if (targetType == typeof(SolidColorBrush))
            return color.ToBrush();

        if (targetType == typeof(string))
            return color.ToHexAarrggbbColorString();

        if (targetType == typeof(int))
            return color.ToInt();

        if (targetType == typeof(uint))
            return (uint)color.ToInt();

        throw new NotImplementedException($"Cannot convert back type [{value.GetType()}] to a [{targetType}]");
    }
}
