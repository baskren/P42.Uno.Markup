using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.SplitView;

namespace P42.Uno.Markup;
public static class SplitViewExtensions
{
    public static TElement CompactPaneLength<TElement>(this TElement element, double value) where TElement : ElementType
    { element.CompactPaneLength = value; return element; }

    public static TElement Content<TElement>(this TElement element, UIElement content) where TElement : ElementType
    { element.Content = content; return element; }

    public static TElement DisplayMode<TElement>(this TElement element, SplitViewDisplayMode value) where TElement : ElementType
    { element.DisplayMode = value; return element; }

    public static TElement IsPaneOpen<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsPaneOpen = value; return element; }

    public static TElement IsPaneClosed<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsPaneOpen = !value; return element; }

    public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
    { element.LightDismissOverlayMode = value; return element; }

    public static TElement OpenPaneLength<TElement>(this TElement element, double value) where TElement : ElementType
    { element.OpenPaneLength = value; return element; }

    public static TElement Pane<TElement>(this TElement element, UIElement pane) where TElement : ElementType
    { element.Pane = pane; return element; }

    #region PaneBackground
    public static ElementType PaneBackground(this ElementType element, Brush brush)
    { element.PaneBackground = brush; return element; }

    public static ElementType PaneBackground(this ElementType element, Windows.UI.Color color)
    { element.PaneBackground = new SolidColorBrush(color); return element; }

    public static ElementType PaneBackground(this ElementType element, string color)
    { element.PaneBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

    public static ElementType PaneBackground(this ElementType element, uint hex)
    { element.PaneBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
    #endregion

    public static TElement PanePlacement<TElement>(this TElement element, SplitViewPanePlacement value) where TElement : ElementType
    { element.PanePlacement = value; return element; }


    #region Events
    public static TElement AddPaneClosedHandler<TElement>(this TElement element, TypedEventHandler<SplitView, object> handler) where TElement : ElementType
    { element.PaneClosed += handler; return element; }

    public static TElement AddPaneClosingHandler<TElement>(this TElement element, TypedEventHandler<SplitView, SplitViewPaneClosingEventArgs> handler) where TElement : ElementType
    { element.PaneClosing += handler; return element; }

    public static TElement AddPaneOpenedHandler<TElement>(this TElement element, TypedEventHandler<SplitView, object> handler) where TElement : ElementType
    { element.PaneOpened += handler; return element; }

    public static TElement AddPaneOpeningHandler<TElement>(this TElement element, TypedEventHandler<SplitView, object> handler) where TElement : ElementType
    { element.PaneOpening += handler; return element; }
    #endregion
}
