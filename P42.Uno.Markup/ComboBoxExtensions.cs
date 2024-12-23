﻿using System;
using Windows.Foundation;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.ComboBox;

namespace P42.Uno.Markup
{
    public static class ComboBoxExtensions
    {
        public static TElement MaxDropDownHeight<TElement>(this TElement element, double value) where TElement : ElementType
        { element.MaxDropDownHeight = value; return element; }

        public static TElement PlaceholderText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.PlaceholderText = value; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.HeaderTemplate = value; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, Type type) where TElement : ElementType
        { element.HeaderTemplate = type.AsDataTemplate(); return element; }

        public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Header = value; return element; }

        public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
        { element.LightDismissOverlayMode = value; return element; }

        public static TElement TextSearchEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTextSearchEnabled = value; return element; }

        public static TElement AddSelectionChangedTrigger<TElement>(this TElement element, ComboBoxSelectionChangedTrigger value) where TElement : ElementType
        { element.SelectionChangedTrigger = value; return element; }

        #region PlaceholderForeground
        public static TElement PlaceholderForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.PlaceholderForeground = value; return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.PlaceholderForeground = new SolidColorBrush(value); return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.PlaceholderForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.PlaceholderForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement TextBoxStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.TextBoxStyle = value; return element; }

        public static TElement Text<TElement>(this TElement element, string value) where TElement : ElementType
        { element.Text = value ?? string.Empty; return element; }

        public static TElement Description<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Description = value; return element; }


        #region Events
        public static TElement AddDropDownClosedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.DropDownClosed += handler; return element; }

        public static TElement AddDropDownOpenedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.DropDownOpened += handler; return element; }

        public static TElement AddTextSubmittedHandler<TElement>(this TElement element, TypedEventHandler<ComboBox, ComboBoxTextSubmittedEventArgs> handler) where TElement : ElementType
        { element.TextSubmitted += handler; return element; }
        #endregion

    }
}
