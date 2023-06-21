using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.BitmapIconSource;
using System.Reflection;
using Microsoft.UI.Xaml.Media.Imaging;

namespace P42.Uno.Markup
{
    public static class BitmapIconSourceExtensions
    {
        public static TElement ShowAsMonochrome<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.ShowAsMonochrome = value; return element; }

        public static TElement UriSource<TElement>(this TElement element, Uri uri) where TElement : ElementType
        { element.UriSource = uri; return element; }

        public static TElement UriSource<TElement>(this TElement element, string uri, Assembly asm = null) where TElement : ElementType
        {
            if (uri.StartsWith("/"))
                uri = "ms-appx://" + uri;

            if (uri.Contains(":/"))
            {
                try
                {
                    var x = new Uri(uri);
                    return element.UriSource(x);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"ImageExtensions.Source: Cannot create Uri from string [{uri}].  Exception: [{e}]");
                    return element;
                }
            }

            System.Console.WriteLine($"ImageExtensions.Source: Cannot find ImageSource from uri string [{uri}].");
            return element;
        }
    }
}