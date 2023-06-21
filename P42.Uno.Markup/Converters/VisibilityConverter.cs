
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
    public class VisibilityConverter : IValueConverter
    {
        static VisibilityConverter visibilityConverter;
        public static VisibilityConverter Instance => visibilityConverter = visibilityConverter ?? new VisibilityConverter();

        private VisibilityConverter() { }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (BooleanConverter.Instance.Convert(value, targetType, parameter, language) is bool boolResult)
                return boolResult
                    ? Visibility.Visible
                    : Visibility.Collapsed;

            throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
            /*
            if (value is null)
                return Visibility.Collapsed;
            if (value is bool tf)
                return tf ? Visibility.Visible : Visibility.Collapsed;
            if (value is Color color)
                return color.A > 0 ? Visibility.Visible : Visibility.Collapsed;
            if (value is Brush brush)
            {
                if (brush is SolidColorBrush solidBrush)
                    return solidBrush.Color.A > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            if (value is int intValue)
                return intValue > 0 ? Visibility.Visible : Visibility.Collapsed;
            if (value is double doubleValue)
                return doubleValue > 0 ? Visibility.Visible : Visibility.Collapsed;
            if (value is string text)
                return string.IsNullOrWhiteSpace(text) ? Visibility.Collapsed : Visibility.Visible;
            if (value is IEnumerable enumerable)
            {
                var e = enumerable.GetEnumerator();
                return e.MoveNext() ? Visibility.Visible : Visibility.Collapsed;                
            }
            return Visibility.Visible;
            */
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
                return BooleanConverter.Instance.ConvertBack(visibility == Visibility.Visible, targetType, parameter, language);

            throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
            /*
            if (value is Visibility visibility)
            {
                if (targetType == typeof(bool))
                    return visibility == Visibility.Visible;
                if (targetType == typeof(Color))
                {
                    return visibility == Visibility.Visible
                        ? parameter as Color? ?? Colors.Red
                        : Colors.Transparent;
                }
                if (targetType == typeof(Brush))
                {
                    if (parameter is Brush brush)
                        return visibility == Visibility.Visible ? brush : null;
                    if (parameter is Color color)
                        return visibility == Visibility.Visible ? new SolidColorBrush(color) : null;
                    return visibility == Visibility.Visible ? new SolidColorBrush(Colors.Red) : null;
                }
                if (targetType == typeof(string))
                    return visibility == Visibility.Visible
                        ? parameter as string ?? "visible"
                        : null;
                if (targetType == typeof(int))
                    return visibility == Visibility.Visible
                        ? parameter as int? ?? 1
                        : 0;
                if (targetType == typeof(double))
                    return visibility == Visibility.Visible
                        ? parameter as double? ?? 1.0
                        : 0.0;
            }

            throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
            */
        }
    }

}