using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.SwipeItem;
using System.Windows.Input;
using Windows.Foundation;
using Microsoft.UI.Xaml.Documents;
using Windows.UI.Text;
using Microsoft.UI.Text;

namespace P42.Uno.Markup
{
    public static class SwipeItemExtensions
    {
        #region Properties

        #region Background
        public static TElement Background<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Background = brush; return element; }

        public static TElement Background<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Background = new SolidColorBrush(color); return element; }

        public static TElement Background<TElement>(this TElement element, string color) where TElement : ElementType
        { element.Background = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement Background<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.Background = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion


        public static TElement BehaviorOnInvoked<TElement>(this TElement element, SwipeBehaviorOnInvoked behavior) where TElement : ElementType
        {
            element.BehaviorOnInvoked = behavior;
            return element;
        }

        public static TElement Command<TElement>(this TElement element, ICommand command) where TElement : ElementType
        {
            element.Command = command;
            return element;
        }

        public static TElement CommandParameter<TElement>(this TElement element, object commandParameter) where TElement : ElementType
        {
            element.CommandParameter = commandParameter;
            return element;
        }

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


        #region IconSource
        public static TElement Icon<TElement>(this TElement element, IconSource value = null) where TElement : ElementType
        { element.IconSource = value; return element; }

        public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
        { element.IconSource = new SymbolIconSource { Symbol = value }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = fontFamily, Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = new FontFamily(fontFamily), Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily, double fontSize) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = new FontFamily(fontFamily), FontSize = fontSize, Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
        { element.IconSource = new PathIconSource { Data = path }; return element; }

        public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
        { element.IconSource = new BitmapIconSource { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
        #endregion


        public static TElement Text<TElement>(this TElement element, string text) where TElement : ElementType
        {
            element.Text = text ?? string.Empty;
            return element;
        }

        #endregion


        #region Events
        public static TElement AddInvokedEventHandler<TElement>(this TElement element, TypedEventHandler<SwipeItem, SwipeItemInvokedEventArgs> handler) where TElement : ElementType
        { element.Invoked += handler; return element; }


        #endregion
    }
}
