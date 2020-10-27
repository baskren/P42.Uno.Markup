using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using ElementType = Windows.UI.Xaml.Controls.Primitives.FlyoutBase;

namespace P42.Uno.Markup
{
    public static class FlyoutBaseExtensions
    {
        public static TElement Placement<TElement>(this TElement element, FlyoutPlacementMode value) where TElement : ElementType
        { element.Placement = value; return element; }

        public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
        { element.LightDismissOverlayMode = value; return element; }

        public static TElement ElementSoundMode<TElement>(this TElement element, ElementSoundMode value) where TElement : ElementType
        { element.ElementSoundMode = value; return element; }

        public static TElement AllowFocusWhenDisabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.AllowFocusWhenDisabled = value; return element; }

        public static TElement AllowFocusOnInteraction<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.AllowFocusOnInteraction = value; return element; }

        public static TElement OverlayInputPassThroughElement<TElement>(this TElement element, DependencyObject value) where TElement : ElementType
        { element.OverlayInputPassThroughElement = value; return element; }

        public static TElement ShowMode<TElement>(this TElement element, FlyoutShowMode value) where TElement : ElementType
        { element.ShowMode = value; return element; }

        public static TElement AreOpenCloseAnimationsEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.AreOpenCloseAnimationsEnabled = value; return element; }

        #region Events
#if NETFX_CORE
        public static TElement AddClosed<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddOpened<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddOpening<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opening += handler; return element; }
#else
        public static TElement AddClosed<TElement>(this TElement element, EventHandler handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddOpened<TElement>(this TElement element, EventHandler handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddOpening<TElement>(this TElement element, EventHandler handler) where TElement : ElementType
        { element.Opening += handler; return element; }
#endif

        public static TElement AddClosing<TElement>(this TElement element, TypedEventHandler<FlyoutBase, FlyoutBaseClosingEventArgs> handler) where TElement : ElementType
        { element.Closing += handler; return element; }
#endregion
    }
}
