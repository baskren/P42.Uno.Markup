using System;
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