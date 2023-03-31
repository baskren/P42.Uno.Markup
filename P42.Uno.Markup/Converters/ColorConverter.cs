using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Windows.UI;

namespace P42.Uno.Markup
{
    public class ColorConverter : TypeConverter, IValueConverter
    {
        public static ColorConverter Instance = new ColorConverter();

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(SolidColorBrush))
                return true;

            if (sourceType == typeof(Color))
                return true;

            if (sourceType == typeof(string))
                return true;

            if (sourceType == typeof(int))
                return true;

            if (sourceType == typeof(uint))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            try
            {
                return Convert(value, typeof(SolidColorBrush), null, null);
            }
            catch (Exception)
            {
                return base.ConvertFrom(context, culture, value);
            }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, [NotNullWhen(true)] Type destinationType)
        {
            return base.CanConvertFrom(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
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

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Color)
                return value;

            if (value is SolidColorBrush brush)
                return brush.Color;

            if (value is string hexText)
                return ColorExtensions.ColorFromString(hexText);

            if (value is uint uintValue)
                return ColorExtensions.ColorFromUint(uintValue);

            if (value is int intValue && intValue >= 0)
                return ColorExtensions.ColorFromUint((uint)intValue);

            var msg = string.Format("Cannot convert \"{0}\" into {1}", value, typeof(Color));
            throw new InvalidOperationException(msg);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var color = (Color)value;

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

            throw new NotImplementedException($"Cannot convert SolidColorBrush back to a [{targetType}]");
        }
    }
}