using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Windows.UI;

namespace P42.Uno.WinUI.Markup;

public class BooleanConverter : TypeConverter, IValueConverter
{
    public static BooleanConverter Instance => field ??= new BooleanConverter();

    private BooleanConverter() { }

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => true;
    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
    {
        if (destinationType == typeof(bool))
            return true;
        if (destinationType == typeof(Color))
            return true;
        if (destinationType == typeof(Visibility))
            return true;
        if (destinationType == typeof(Brush))
            return true;
        if (destinationType == typeof(string))
            return true;
        if (destinationType == typeof(short))
            return true;
        if (destinationType == typeof(int))
            return true;
        if (destinationType == typeof(long))
            return true;
        if (destinationType == typeof(float))
            return true;
        if (destinationType == typeof(double))
            return true;
        if (destinationType == typeof(decimal))
            return true;

        return false;
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        try
        {
            return Convert(value);
        }
        catch (Exception)
        {
            return base.ConvertFrom(context, culture, value);
        }
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
        Type destinationType)
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
    


    public object? Convert(object? value)
        => Convert(value, null, null, null);

    public object? Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        if (parameter is Func<object?,bool> func)
            value = func.Invoke(value);

        if (parameter != null && parameter.GetType() == value?.GetType())
            return value.Equals(parameter);

        switch (value)
        {
            case null:
                return false;
            case bool tf:
                return tf;
            case Color color:
                return color.A > 0;
            case SolidColorBrush solidBrush:
                return solidBrush.Color.A > 0;
            case short shortValue:
                return shortValue > 0;
            case int intValue:
                return intValue > 0;
            case long longValue:
                return longValue > 0;
            case float floatValue:
                return floatValue > 0;
            case double doubleValue:
                return doubleValue > 0;
            case decimal decimalValue:
                return decimalValue > 0;
            case string text when text.Equals("true", StringComparison.OrdinalIgnoreCase):
                // ReSharper disable once DuplicatedStatements
                return true;
            case string text when text.Equals("false", StringComparison.OrdinalIgnoreCase):
                return false;
            case string text when text.Equals("yes", StringComparison.OrdinalIgnoreCase):
                // ReSharper disable once DuplicatedStatements
                return true;
            case string text when text.Equals("no", StringComparison.OrdinalIgnoreCase):
                return false;
            case string text when text.Equals("visible", StringComparison.OrdinalIgnoreCase):
                // ReSharper disable once DuplicatedStatements
                return true;
            case string text when text.Equals("collapsed", StringComparison.OrdinalIgnoreCase):
                return false;
            case string text:
                return !string.IsNullOrWhiteSpace(text);
            case IEnumerable enumerable:
            {
                var e = enumerable.GetEnumerator();
                var result = e.MoveNext();
                if (e is IDisposable disposable)
                    disposable.Dispose();
                return result;
            }
            case Visibility visibility:
                return visibility == Visibility.Visible;
        }

        return true;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        if (value is bool boolValue)
        {
            if (parameter is Func<bool, object> func)
                return func.Invoke(boolValue);

            if (parameter != null && parameter.GetType() == targetType)
            {
                if (boolValue) return parameter;
                return targetType.IsValueType 
                    ? Activator.CreateInstance(targetType) 
                    : null;
            }

            if (targetType == typeof(bool))
                return boolValue;

            if (targetType == typeof(Color))
            {
                return boolValue
                    ? parameter as Color? ?? Colors.Red
                    : Colors.Transparent;
            }
            
            if (targetType == typeof(Visibility))
                return boolValue
                    ? Visibility.Visible : Visibility.Collapsed;
            
            if (targetType == typeof(Brush))
            {
                return parameter switch
                {
                    Brush brush => boolValue ? brush : null,
                    Color color => boolValue ? new SolidColorBrush(color) : null,
                    _ => boolValue ? new SolidColorBrush(Colors.Red) : null
                };
            }
            
            if (targetType == typeof(string))
                return boolValue
                    ? parameter as string ?? "true"
                    : null;
            if (targetType == typeof(short))
                return boolValue
                    ? parameter as short? ?? 1
                    : 0;
            if (targetType == typeof(int))
                return boolValue
                    ? parameter as int? ?? 1
                    : 0;
            if (targetType == typeof(long))
                return boolValue
                    ? parameter as long? ?? 1
                    : 0;
            if (targetType == typeof(float))
                return boolValue
                    ? parameter as float? ?? 1
                    : 0;
            if (targetType == typeof(double))
                return boolValue
                    ? parameter as double? ?? 1.0
                    : 0.0;
            if (targetType == typeof(decimal))
                return boolValue
                    ? parameter as decimal? ?? 1
                    : 0;

        }

        throw new InvalidCastException($"Cannot P42.Uno.Markup.BoolConverter.ConvertBack({value},{targetType}) ");
    }
}
