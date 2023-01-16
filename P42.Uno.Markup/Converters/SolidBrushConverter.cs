using Microsoft.UI.Xaml.Media;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Windows.UI;

namespace P42.Uno.Markup
{
    public class FlexAlignContentTypeConverter : TypeConverter
    {
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
            if (value is SolidColorBrush)
                return value;

            if (value is Color color)
                return color.ToBrush();

            if (value is string hexText)
                return new SolidColorBrush(ColorExtensions.ColorFromString(hexText));

            if (value is uint uintValue)
                return new SolidColorBrush(ColorExtensions.ColorFromUint(uintValue));

            if (value is int intValue && intValue >= 0) 
                return new SolidColorBrush(ColorExtensions.ColorFromUint((uint)intValue));
            
            return base.ConvertFrom(context, culture, value);

            //var msg = string.Format("Cannot convert \"{0}\" into {1}", value, typeof(SolidColorBrush));
            //throw new InvalidOperationException(msg);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, [NotNullWhen(true)] Type destinationType)
        {
            return base.CanConvertFrom(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            SolidColorBrush brush = (SolidColorBrush)value; 

            if (destinationType == typeof(SolidColorBrush))
                return brush;

            var color = brush.Color;
            if (destinationType == typeof(Color))
                return color;

            if (destinationType == typeof(string))
                return color.ToHexAarrggbbColorString();

            if (destinationType == typeof(int))
                return color.ToInt();

            if (destinationType == typeof(uint))
                return (uint)color.ToInt();

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}