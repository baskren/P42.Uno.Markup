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


        public static TElement IconSource<TElement>(this TElement element, IconSource iconSource) where TElement : ElementType
        {
            element.IconSource = iconSource;
            return element;
        }

        public static TElement IconSource<TElement>(this TElement element, Symbol symbol) where TElement : ElementType
        {
            element.IconSource = new SymbolIconSource { Symbol = symbol };
            return element;
        }

        public static TElement IconSource<TElement>(this TElement element, Geometry path) where TElement : ElementType
        {
            element.IconSource = new PathIconSource { Data = path };
            return element;
        }

        public static TElement IconSource<TElement>(this TElement element, string glyph, FontFamily fontFamily, double fontSize = default, FontWeight fontWeight = default, FontStyle fontStyle = default, bool isTextScaleFactorEnabled = false, bool mirroredWhenRightToLeft = false) where TElement : ElementType
        {
            var source = new FontIconSource
            {
                Glyph = glyph,
                FontFamily = fontFamily,
                IsTextScaleFactorEnabled = isTextScaleFactorEnabled,
                MirroredWhenRightToLeft = mirroredWhenRightToLeft
            };
            if (fontSize != default) source.FontSize = fontSize;
            if (fontStyle != default) source.FontStyle = fontStyle;
            if (fontWeight != default) source.FontWeight = fontWeight;

            element.IconSource = source;
            return element;
        }

        public static TElement IconSource<TElement>(this TElement element, Uri uriSource, bool showAsMonoChrome = true) where TElement : ElementType
        {
            element.IconSource = new BitmapIconSource { UriSource = uriSource, ShowAsMonochrome = showAsMonoChrome };
            return element;
        }

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