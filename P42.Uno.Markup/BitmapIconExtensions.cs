using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.BitmapIcon;

namespace P42.Uno.Markup
{
    public static class BitmapIconExtensions
    {
        public static TElement ShowAsMonochrome<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.ShowAsMonochrome = value; return element; }

        public static TElement UriSource<TElement>(this TElement element, Uri uri) where TElement : ElementType
        { element.UriSource = uri; return element; }

    }
}