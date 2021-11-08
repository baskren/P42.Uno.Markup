using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using ElementType = Windows.UI.Xaml.Controls.AppBar;

namespace P42.Uno.Markup
{
    public static class AppBarExtensions
    {
        public static TElement Sticky<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSticky = value; return element; }

        public static TElement Open<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsOpen = value; return element; }

        public static TElement ClosedDisplayMode<TElement>(this TElement element, AppBarClosedDisplayMode value) where TElement : ElementType
        { element.ClosedDisplayMode = value; return element; }

        public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
        { element.LightDismissOverlayMode = value; return element; }


        #region Events
        public static TElement AddOnClosed<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddOnOpened<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddOnClosing<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Closing += handler; return element; }

        public static TElement AddOnOpening<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opening += handler; return element; }

        #endregion
    }
}
