
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
        public static VisibilityConverter Instance => visibilityConverter ??= new VisibilityConverter();

        private VisibilityConverter() { }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (BooleanConverter.Instance.Convert(value, targetType, parameter, language) is bool boolResult)
                return boolResult
                    ? Visibility.Visible
                    : Visibility.Collapsed;

            throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
                return BooleanConverter.Instance.ConvertBack(visibility == Visibility.Visible, targetType, parameter, language);

            throw new InvalidCastException($"Cannot P42.Uno.Markup.VisibilityConverter.ConvertBack({value},{targetType}) ");
        }
    }

    public class CollapsedConverter : IValueConverter
    {
        static CollapsedConverter collapsedConverter;
        public static CollapsedConverter Instance => collapsedConverter ??= new CollapsedConverter();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (BooleanConverter.Instance.Convert(value, targetType, parameter, language) is bool boolResult)
                return boolResult
                    ? Visibility.Collapsed
                    : Visibility.Visible;

            throw new InvalidCastException($"Cannot P42.Uno.Markup.CollapsedConverter.ConvertBack({value},{targetType}) ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
                return BooleanConverter.Instance.ConvertBack(visibility == Visibility.Collapsed, targetType, parameter, language);

            throw new InvalidCastException($"Cannot P42.Uno.Markup.CollapsedConverter.ConvertBack({value},{targetType}) ");
        }
    }
}