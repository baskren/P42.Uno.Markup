using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;
using static System.Net.Mime.MediaTypeNames;

namespace P42.Uno.Markup
{
    public class InverseVisibilityConverter : IValueConverter
    {
        static InverseVisibilityConverter inverseVisibilityConverter;
        public static InverseVisibilityConverter Instance => inverseVisibilityConverter = inverseVisibilityConverter ?? new InverseVisibilityConverter();

        private InverseVisibilityConverter() { }

        public object Convert(object value, Type targetType, object parameter, string language)

        {
            if (VisibilityConverter.Instance.Convert(value, targetType, parameter, language) is Visibility visibility)
            {
                if (visibility == Visibility.Visible)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }

            throw new Exception("P42.Uno.Markup.InverseVisibilityConverter.Convert failed");
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
            {
                if (visibility == Visibility.Collapsed)
                    return VisibilityConverter.Instance.ConvertBack(Visibility.Visible, targetType, parameter, language);
                return VisibilityConverter.Instance.ConvertBack(Visibility.Collapsed, targetType, parameter, language);
            }

            throw new InvalidCastException($"Cannot P42.Uno.Markup.InverseVisibilityConverter.ConvertBack({value},{targetType}) ");
        }
    }
}