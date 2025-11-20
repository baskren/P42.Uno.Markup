using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace P42.Uno.WinUI.Markup;

public class VisibilityConverter : TypeConverter, IValueConverter
{
    private static VisibilityConverter? _visibilityConverter;
    public static VisibilityConverter Instance => _visibilityConverter ??= new VisibilityConverter();

    private VisibilityConverter() { }

    
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => BooleanConverter.Instance.CanConvertFrom(context, sourceType);

    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
        => BooleanConverter.Instance.CanConvertTo(context, destinationType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        try
        {
            return Convert(value, typeof(Visibility), null, null);
        }
        catch (Exception)
        {
            return Visibility.Visible;
        }
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
        Type destinationType)
    {
        try
        {
            return ConvertBack(value, destinationType, null, null);
        }
        catch (Exception )
        {
            return null;
        }
    }

    // ReSharper disable once ReturnTypeCanBeNotNullable
    public object? Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        if (BooleanConverter.Instance.Convert(value, targetType, parameter, language) is bool boolResult)
            return boolResult
                ? Visibility.Visible
                : Visibility.Collapsed;

        throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        if (value is Visibility visibility)
            return BooleanConverter.Instance.ConvertBack(visibility == Visibility.Visible, targetType, parameter, language);

        throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
    }
}

public class CollapsedConverter : TypeConverter, IValueConverter
{
    private static CollapsedConverter? _collapsedConverter;
    public static CollapsedConverter Instance => _collapsedConverter ??= new CollapsedConverter();

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => BooleanConverter.Instance.CanConvertFrom(context, sourceType);

    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
        => BooleanConverter.Instance.CanConvertTo(context, destinationType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        try
        {
            return Convert(value, typeof(Visibility), null, null);
        }
        catch (Exception)
        {
            return Visibility.Visible;
        }
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
        Type destinationType)
    {
        try
        {
            return ConvertBack(value, destinationType, null, null);
        }
        catch (Exception )
        {
            return null;
        }
    }


    // ReSharper disable once ReturnTypeCanBeNotNullable
    public object? Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        if (BooleanConverter.Instance.Convert(value, targetType, parameter, language) is bool boolResult)
            return boolResult
                ? Visibility.Collapsed
                : Visibility.Visible;

        throw new InvalidCastException($"Cannot P42.Uno.Markup.CollapsedConverter.ConvertBack({value},{targetType}) ");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        if (value is Visibility visibility)
            return BooleanConverter.Instance.ConvertBack(visibility == Visibility.Collapsed, targetType, parameter, language);

        throw new InvalidCastException($"Cannot P42.Uno.Markup.CollapsedConverter.ConvertBack({value},{targetType}) ");
    }
}
