﻿using System;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using ElementType = Microsoft.UI.Xaml.Controls.Primitives.FlyoutBase;

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
        public static TElement AddClosedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddOpenedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddOpeningHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.Opening += handler; return element; }

        public static TElement AddClosingHandler<TElement>(this TElement element, TypedEventHandler<FlyoutBase, FlyoutBaseClosingEventArgs> handler) where TElement : ElementType
        { element.Closing += handler; return element; }
        #endregion
    }
}
