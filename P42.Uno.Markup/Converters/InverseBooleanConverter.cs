using Microsoft.UI.Xaml.Data;
using System;

namespace P42.Uno.Markup
{
    public class InverseBooleanConverter : IValueConverter
    {
        static InverseBooleanConverter inverseVisibilityConverter;
        public static InverseBooleanConverter Instance => inverseVisibilityConverter = inverseVisibilityConverter ?? new InverseBooleanConverter();

        private InverseBooleanConverter() { }

        public object Convert(object value, Type targetType, object parameter, string language)

        {
            if (BooleanConverter.Instance.Convert(value, targetType, parameter, language) is bool boolResult)
                return !boolResult;

            throw new Exception("P42.Uno.Markup.InverseBooleanConverter.Convert failed");
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
                return BooleanConverter.Instance.ConvertBack(!boolValue, targetType, parameter, language);

            throw new InvalidCastException($"Cannot P42.Uno.Markup.InverseBooleanConverter.ConvertBack({value},{targetType}) ");
        }
    }
}