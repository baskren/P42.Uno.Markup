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
        public static TElement IsSticky<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSticky = value; return element; }

        public static TElement IsOpen<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsOpen = value; return element; }

        public static TElement ClosedDisplayMode<TElement>(this TElement element, AppBarClosedDisplayMode value) where TElement : ElementType
        { element.ClosedDisplayMode = value; return element; }

        public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
        { element.LightDismissOverlayMode = value; return element; }


        #region Events
        public static TElement AddClosed<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddOpened<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddClosing<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Closing += handler; return element; }

        public static TElement AddOpening<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opening += handler; return element; }

        #endregion
    }
}
