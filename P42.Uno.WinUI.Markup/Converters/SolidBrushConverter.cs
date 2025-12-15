using System.ComponentModel;
using System.Globalization;
using Windows.UI;
using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

public class SolidBrushConverter : TypeConverter, IValueConverter
{
    public static SolidBrushConverter Instance => field ??= new SolidBrushConverter();

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => ColorConverter.Instance.CanConvertFrom(context, sourceType);

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        => ColorConverter.Instance.CanConvertTo(context, destinationType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (ColorConverter.Instance.ConvertFrom(context, culture, value) is Color color)
            return color.ToBrush();
        
        return null;
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
        Type destinationType)
    {
        value ??= default(Color);
        
        return ColorConverter.Instance.ConvertFrom(context, culture, value) is not Color color 
            ? null 
            : ColorConverter.Instance.ConvertTo(context, culture, color, destinationType);
    }

    public object Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        if (ColorConverter.Instance.Convert(value, targetType, parameter, language) is Color color)
            return color.ToBrush();
        
        var msg = $"Cannot convert \"{value}\" into {typeof(SolidColorBrush)}";
        throw new InvalidOperationException(msg);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        var color = value is SolidColorBrush brush
            ? brush.Color
            : default;

        return ColorConverter.Instance.ConvertBack(color, targetType, parameter, language);
    }
}
