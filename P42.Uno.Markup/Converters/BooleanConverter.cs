
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections;
using Windows.UI;
using System.Linq;
using System.Collections.ObjectModel;

namespace P42.Uno.Markup
{
    public class BooleanConverter : IValueConverter
    {
        static BooleanConverter visibilityConverter;
        public static BooleanConverter Instance => visibilityConverter = visibilityConverter ?? new BooleanConverter();

        private BooleanConverter() { }

        public object Convert(object value)
            => Convert(value, null, null, null);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is Func<object,bool> func)
                value = func.Invoke(value);

            if (parameter != null && parameter.GetType() == value.GetType())
                return value.Equals(parameter);

            if (value is null)
                return false;
            if (value is bool tf)
                return tf;
            if (value is Color color)
                return color.A > 0;
            if (value is Brush brush)
            {
                if (brush is SolidColorBrush solidBrush)
                    return solidBrush.Color.A > 0;
            }
            if (value is short shortValue)
                return shortValue > 0;
            if (value is int intValue)
                return intValue > 0;
            if (value is long longValue)
                return longValue > 0;
            if (value is float floatValue)
                return floatValue > 0;
            if (value is double doubleValue)
                return doubleValue > 0;
            if (value is decimal decimalValue)
                return decimalValue > 0;
            if (value is string text)
            {
                if (text.Equals("true", StringComparison.OrdinalIgnoreCase))
                    return true;
                if (text.Equals("false", StringComparison.OrdinalIgnoreCase))
                    return false;
                if (text.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    return true;
                if (text.Equals("no", StringComparison.OrdinalIgnoreCase))
                    return false;
                if (text.Equals("visible", StringComparison.OrdinalIgnoreCase))
                    return true;
                if (text.Equals("collapsed", StringComparison.OrdinalIgnoreCase))
                    return false;
                return !string.IsNullOrWhiteSpace(text);
            }
            if (value is IEnumerable enumerable)
            {
                var e = enumerable.GetEnumerator();
                return e.MoveNext();                
            }
            if (value is Visibility visibility)
                return visibility == Visibility.Visible;

            throw new InvalidCastException($"Cannot P42.Uno.Markup.BoolConverter.ConvertBack({value},{targetType}) ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
            {
                if (parameter is Func<bool, object> func)
                    return func?.Invoke(boolValue);

                if (parameter != null && parameter.GetType() == targetType)
                {
                    if (boolValue) return parameter;
                    if (targetType.IsValueType)
                        return Activator.CreateInstance(targetType);
                    return null;
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
                    if (parameter is Brush brush)
                        return boolValue ? brush : null;
                    if (parameter is Color color)
                        return boolValue ? new SolidColorBrush(color) : null;
                    return boolValue ? new SolidColorBrush(Colors.Red) : null;
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

}
