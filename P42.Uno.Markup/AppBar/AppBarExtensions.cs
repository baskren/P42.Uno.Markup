using System;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.AppBar;

namespace P42.Uno.Markup;

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
    public static TElement AddClosedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.Closed += handler; return element; }

    public static TElement AddOpenedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.Opened += handler; return element; }

    public static TElement AddClosingHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.Closing += handler; return element; }

    public static TElement AddOpeningHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.Opening += handler; return element; }

    #endregion
}