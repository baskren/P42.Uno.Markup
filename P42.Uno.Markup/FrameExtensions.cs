using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using ElementType = Microsoft.UI.Xaml.Controls.Frame;

namespace P42.Uno.Markup
{
    public static class FrameExtensions
    {
        public static TElement SourcePageType<TElement>(this TElement element, Type value) where TElement : ElementType
        { element.SourcePageType = value; return element; }

        public static TElement CacheSize<TElement>(this TElement element, int value) where TElement : ElementType
        { element.CacheSize = value; return element; }

        public static TElement NavigationStackEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsNavigationStackEnabled = value; return element; }

        public static TElement AddNavigatedHandler<TElement>(this TElement element, NavigatedEventHandler value) where TElement : ElementType
        { element.Navigated += value; return element; }

        public static TElement AddNavigatingHandler<TElement>(this TElement element, NavigatingCancelEventHandler value) where TElement : ElementType
        { element.Navigating += value; return element; }

        public static TElement AddNavigationFailedHandler<TElement>(this TElement element, NavigationFailedEventHandler value) where TElement : ElementType
        { element.NavigationFailed += value; return element; }

        public static TElement AddNavigationStoppedHandler<TElement>(this TElement element, NavigationStoppedEventHandler value) where TElement : ElementType
        { element.NavigationStopped += value; return element; }

    }
}