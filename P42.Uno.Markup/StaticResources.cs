using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P42.Uno.Markup;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup
{
    public static class StaticResources
    {
        public static T TryGetAppResourceAs<T>(string key)
            => Application.Current.Resources.TryGetAs<T>(key);

        public static T TryGetResourceAs<T>(this FrameworkElement d, string key)
            => d.Resources.TryGetAs<T>(key);

        public static T TryGetAs<T>(this ResourceDictionary resourceDictionary, string key)
        {
            if (resourceDictionary.TryGetValue(key, out object value))
            {
                if (typeof(T) == typeof(Brush) &&
                    SolidBrushConverter.Instance.CanConvertFrom(value.GetType()) &&
                    SolidBrushConverter.Instance.Convert(value, value.GetType(), null, null) is T tBrush
                    )
                    return tBrush;

                if (typeof(T) == typeof(Color) &&
                    ColorConverter.Instance.CanConvertFrom(value.GetType()) &&
                    ColorConverter.Instance.Convert(value, value.GetType(), null, null) is T tColor
                    )
                    return tColor;

                if (value is T tValue)
                    return tValue;

                Console.WriteLine($"Could not convert Application.Current.Resource for key [{key}] from type [{value.GetType()}] to [{value.GetType()}]");
            }
            else
                Console.WriteLine($"Could not find Application.Current.Resource for key [{key}]");

            return default;
        }

        public static Microsoft.UI.Xaml.Media.FontFamily SymbolThemeFontFamily => TryGetAppResourceAs<Microsoft.UI.Xaml.Media.FontFamily>("SymbolThemeFontFamily");
    }
}
