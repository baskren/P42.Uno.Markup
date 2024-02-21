using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using Windows.UI;
using ElementType = Microsoft.UI.Xaml.Controls.WebView2;


namespace P42.Uno.Markup;
public static class WebView2Extensions
{

    public static TElement CanGoBack<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.CanGoBack = value; return element; }

    public static TElement CanGoForward<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.CanGoForward = value; return element; }

    public static TElement DefaultBackgroundColor<TElement>(this TElement element, Color value) where TElement : ElementType
    { element.DefaultBackgroundColor = value; return element; }

    public static TElement DefaultBackgroundColor<TElement>(this TElement element, string color) where TElement : ElementType
    { element.DefaultBackgroundColor = ColorExtensions.ColorFromString(color); return element; }

    public static TElement DefaultBackgroundColor<TElement>(this TElement element, uint hex) where TElement : ElementType
    { element.DefaultBackgroundColor = ColorExtensions.ColorFromUint(hex); return element; }

    public static TElement Source<TElement>(this TElement element, Uri value) where TElement : ElementType
    { element.Source = value; return element; }

    #region Event Handlers
    public static TElement AddCoreProcessFailedHandler<TElement>(this TElement element, TypedEventHandler<WebView2, CoreWebView2ProcessFailedEventArgs> handler) where TElement : ElementType
    { element.CoreProcessFailed += handler; return element; }

    public static TElement AddCoreWebView2InitializedHandler<TElement>(this TElement element, TypedEventHandler<WebView2, CoreWebView2InitializedEventArgs> value) where TElement : ElementType
    { element.CoreWebView2Initialized += value; return element; }

    public static TElement AddNavigationCompletedHandler<TElement>(this TElement element, TypedEventHandler<WebView2, CoreWebView2NavigationCompletedEventArgs> handler) where TElement : ElementType
    { element.NavigationCompleted += handler; return element; }

    public static TElement AddNavigationStartingHandler<TElement>(this TElement element, TypedEventHandler<WebView2, CoreWebView2NavigationStartingEventArgs> handler) where TElement : ElementType
    { element.NavigationStarting += handler; return element; }

    public static TElement AddWebMessageReceivedHandler<TElement>(this TElement element, TypedEventHandler<WebView2, CoreWebView2WebMessageReceivedEventArgs> handler) where TElement : ElementType
    { element.WebMessageReceived += handler; return element; }



    #endregion
}
