using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.IconSource;

namespace P42.Uno.Markup
{
    public static class IconSourceExtensions
    {
        #region Foreground
        public static TElement Foreground<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Foreground = brush; return element; }

        public static TElement Foreground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(color); return element; }

        public static TElement Foreground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement Foreground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion


    }
}