using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.IconElement;

namespace P42.Uno.Markup
{
    public static class IconElementExtensions
    {
        #region Foreground
        public static TElement Foreground<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Foreground = brush; return element; }

        public static TElement Foreground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(color); return element; }

        public static TElement Foreground<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(ColorExtensions.ColorFromString(hex)); return element; }
        #endregion

    }
}
