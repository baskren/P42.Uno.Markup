﻿using P42.Utils.Uno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.Control;

namespace P42.Uno.Markup
{
    public static class ControlExtensions
    {
        #region Padding
        public static TElement Padding<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Padding = new Thickness(value); return element; }

        public static TElement Padding<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement Padding<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.Padding = new Thickness(left, top, right, bottom); return element; }

        public static TElement Padding<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.Padding = padding; return element; }
        #endregion


        #region IsTabStop
        public static TElement IsTabStop<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.IsTabStop = value; return element; }

        public static TElement TabStop<TElement>(this TElement element) where TElement : ElementType
        { element.IsTabStop = true; return element; }
        #endregion


        #region IsEnabled
        public static TElement IsEnabled<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.IsEnabled = value; return element; }

        public static TElement Enabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsEnabled = value; return element; }
        #endregion


        #region Content Alignment

        public static TElement ContentCenter<TElement>(this TElement element) where TElement : ElementType
        { 
            element.HorizontalContentAlignment = HorizontalAlignment.Center;
            element.VerticalContentAlignment = VerticalAlignment.Center;
            return element; 
        }

        public static TElement ContentStretch<TElement>(this TElement element) where TElement : ElementType
        { 
            element.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            element.VerticalContentAlignment = VerticalAlignment.Stretch;
            return element; 
        }

        #region Horizontal
        public static TElement HorizontalContentAlignment<TElement>(this TElement element, HorizontalAlignment value) where TElement : ElementType
        { element.HorizontalContentAlignment = value; return element; }

        public static TElement ContentLeft<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Left; return element; }

        public static TElement ContentRight<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Right; return element; }

        public static TElement ContentHorizontalCenter<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Center; return element; }

        public static TElement ContentHorizontalStretch<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Stretch; return element; }
        #endregion

        #region Vertical
        public static TElement VerticalContentAlignment<TElement>(this TElement element, VerticalAlignment value) where TElement : ElementType
        { element.VerticalContentAlignment = value; return element; }

        public static TElement ContentTop<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Top; return element; }

        public static TElement ContentBottom<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Bottom; return element; }

        public static TElement ContentVerticalCenter<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Center; return element; }

        public static TElement ContentVerticalStretch<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Stretch; return element; }

        #endregion

        #endregion


        #region Font Properties

        #region Binding
        public static TElement BindFont<TElement>(this TElement target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null) where TElement : ElementType
        {
            var excepts = InternalHelpers.GetExcepts<Control>(except);
            if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
                target.Bind(ElementType.FontFamilyProperty, source, nameof(Control.FontFamily), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
                target.Bind(ElementType.FontSizeProperty, source, nameof(Control.FontSize), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
                target.Bind(ElementType.FontStretchProperty, source, nameof(Control.FontStretch), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
                target.Bind(ElementType.FontStyleProperty, source, nameof(Control.FontStyle), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
                target.Bind(ElementType.FontWeightProperty, source, nameof(Control.FontWeight), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
                target.Bind(ElementType.ForegroundProperty, source, nameof(Control.Foreground), bindingMode);
            return target;
        }
        public static TElement BindFont<TElement>(this TElement target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null) where TElement : ElementType
        {
            var excepts = InternalHelpers.GetExcepts<TextBlock>(except);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
                target.Bind(ElementType.FontFamilyProperty, source, nameof(TextBlock.FontFamily), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
                target.Bind(ElementType.FontSizeProperty, source, nameof(TextBlock.FontSize), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
                target.Bind(ElementType.FontStretchProperty, source, nameof(TextBlock.FontStretch), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
                target.Bind(ElementType.FontStyleProperty, source, nameof(TextBlock.FontStyle), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
                target.Bind(ElementType.FontWeightProperty, source, nameof(TextBlock.FontWeight), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
                target.Bind(ElementType.ForegroundProperty, source, nameof(TextBlock.Foreground), bindingMode);
            return target;
        }
        public static TElement BindFont<TElement>(this TElement target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null) where TElement : ElementType
        {
            var excepts = InternalHelpers.GetExcepts<ContentPresenter>(except);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
                target.Bind(ElementType.FontFamilyProperty, source, nameof(ContentPresenter.FontFamily), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
                target.Bind(ElementType.FontSizeProperty, source, nameof(ContentPresenter.FontSize), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
                target.Bind(ElementType.FontStretchProperty, source, nameof(ContentPresenter.FontStretch), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
                target.Bind(ElementType.FontStyleProperty, source, nameof(ContentPresenter.FontStyle), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
                target.Bind(ElementType.FontWeightProperty, source, nameof(ContentPresenter.FontWeight), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
                target.Bind(ElementType.ForegroundProperty, source, nameof(ContentPresenter.Foreground), bindingMode);
            return target;
        }
        #endregion


        #region Foreground
        public static TElement Foreground<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Foreground = brush; return element; }

        public static TElement Foreground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(color); return element; }

        public static TElement Foreground<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromString(hex)); return element; }
        #endregion


        #region FontWeight
        public static TElement FontWeight<TElement>(this TElement element, FontWeight weight) where TElement : ElementType
        { element.FontWeight = weight; return element; }

        public static TElement Thin<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Thin; return element; }

        public static TElement ExtraLight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraLight; return element; }

        public static TElement Light<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Light; return element; }

        public static TElement SemiLight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.SemiLight; return element; }

        public static TElement NormalFontWeight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Normal; return element; }

        public static TElement Medium<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Medium; return element; }

        public static TElement SemiBold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.SemiBold; return element; }

        public static TElement Bold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Bold; return element; }

        public static TElement ExtraBold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraBold; return element; }

        public static TElement BlackFontWeight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Black; return element; }

        public static TElement ExtraBlack<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraBlack; return element; }
        #endregion


        #region FontStyle
        public static TElement FontStyle<TElement>(this TElement element, FontStyle fontStyle) where TElement : ElementType
        { element.FontStyle = fontStyle; return element; }

        public static TElement NormalFontStyle<TElement>(this TElement element) where TElement : ElementType
        { element.FontStyle = Windows.UI.Text.FontStyle.Normal; return element; }

        public static TElement Oblique<TElement>(this TElement element) where TElement : ElementType
        { element.FontStyle = Windows.UI.Text.FontStyle.Oblique; return element; }

        public static TElement Italic<TElement>(this TElement element) where TElement : ElementType
        { element.FontStyle = Windows.UI.Text.FontStyle.Italic; return element; }
        #endregion


        #region FontStretch
        public static TElement FontStretch<TElement>(this TElement element, FontStretch stretch) where TElement : ElementType
        { element.FontStretch = stretch; return element; }

        public static TElement FontStretch<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Undefined; return element; }

        public static TElement UltraCondensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.UltraCondensed; return element; }

        public static TElement ExtraCondensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.ExtraCondensed; return element; }

        public static TElement Condensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Condensed; return element; }

        public static TElement SemiCondensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.SemiCondensed; return element; }

        public static TElement NormalFontStretch<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Normal; return element; }

        public static TElement SemiExpanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.SemiExpanded; return element; }

        public static TElement Expanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Expanded; return element; }

        public static TElement ExtraExpanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.ExtraExpanded; return element; }

        public static TElement UltraExpanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.UltraExpanded; return element; }
        #endregion


        public static TElement FontSize<TElement>(this TElement element, double size) where TElement : ElementType
        { element.FontSize = size; return element; }


        #region FontFamily
        public static TElement FontFamily<TElement>(this TElement element, FontFamily family) where TElement : ElementType
        { element.FontFamily = family; return element; }

        public static TElement FontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.FontFamily = new Windows.UI.Xaml.Media.FontFamily(family); return element; }
        #endregion

        #endregion


        public static TElement TabIndex<TElement>(this TElement element, int index) where TElement : ElementType
        { element.TabIndex = index; return element; }

        public static TElement CharacterSpacing<TElement>(this TElement element, int ems) where TElement : ElementType
        { element.CharacterSpacing = ems; return element; }


        #region Border Properties

        #region Border Thickness
        public static TElement BorderThickness<TElement>(this TElement element, double value) where TElement : ElementType
        { element.BorderThickness = new Thickness(value); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.BorderThickness = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.BorderThickness = new Thickness(left, top, right, bottom); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.BorderThickness = padding; return element; }
        #endregion


        #region BorderBrush
        public static TElement BorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BorderBrush = value; return element; }

        public static TElement BorderBrush<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(value); return element; }

        public static TElement BorderBrush<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromString(hex)); return element; }
        #endregion


        #region CornerRadius
        public static TElement CornerRadius<TElement>(this TElement element, double value) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(value); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, double topLeft, double topRight, double bottomRight, double bottomLeft) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, CornerRadius padding) where TElement : ElementType
        { element.CornerRadius = padding; return element; }
        #endregion


        #region BindBorder

        public static TElement BindBorder<TElement>(this TElement target, Control source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
        {
            target.Bind(ElementType.BorderBrushProperty, source, nameof(Control.BorderBrush), bindingMode);
            target.Bind(ElementType.BorderThicknessProperty, source, nameof(Control.BorderThickness), bindingMode);
            target.Bind(ElementType.CornerRadiusProperty, source, nameof(Control.CornerRadius), bindingMode);
            return target;
        }
        public static TElement BindBorder<TElement>(this TElement target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
        {
            target.Bind(ElementType.BorderBrushProperty, source, nameof(ContentPresenter.BorderBrush), bindingMode);
            target.Bind(ElementType.BorderThicknessProperty, source, nameof(ContentPresenter.BorderThickness), bindingMode);
            target.Bind(ElementType.CornerRadiusProperty, source, nameof(ContentPresenter.CornerRadius), bindingMode);
            return target;
        }
        public static TElement BindBorder<TElement>(this TElement target, Border source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
        {
            target.Bind(ElementType.BorderBrushProperty, source, nameof(Border.BorderBrush), bindingMode);
            target.Bind(ElementType.BorderThicknessProperty, source, nameof(Border.BorderThickness), bindingMode);
            target.Bind(ElementType.CornerRadiusProperty, source, nameof(Border.CornerRadius), bindingMode);
            return target;
        }

        #endregion


        #endregion

        public static TElement TabNavigation<TElement>(this TElement element, KeyboardNavigationMode value) where TElement : ElementType
        { element.TabNavigation = value; return element; }

        #region Background
        public static TElement Background<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Background = brush; return element; }

        public static TElement Background<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Background = new SolidColorBrush(color); return element; }

        public static TElement Background<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.Background = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromString(hex)); return element; }
        #endregion

        public static TElement Template<TElement>(this TElement element, ControlTemplate value) where TElement : ElementType
        { element.Template = value; return element; }

        public static TElement IsTextScaleFactorEnabled<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.IsTextScaleFactorEnabled = value; return element; }

        public static TElement TextScaleFactorEnabled<TElement>(this TElement element) where TElement : ElementType
        { element.IsTextScaleFactorEnabled = true; return element; }

        #region Focus
        public static TElement UseSystemFocusVisuals<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.UseSystemFocusVisuals = value; return element; }

        public static TElement XYFocusUp<TElement>(this TElement element, DependencyObject value) where TElement : ElementType
        { element.XYFocusUp = value; return element; }

        public static TElement XYFocusRight<TElement>(this TElement element, DependencyObject value) where TElement : ElementType
        { element.XYFocusRight = value; return element; }

        public static TElement XYFocusLeft<TElement>(this TElement element, DependencyObject value) where TElement : ElementType
        { element.XYFocusLeft = value; return element; }

        public static TElement XYFocusDown<TElement>(this TElement element, DependencyObject value) where TElement : ElementType
        { element.XYFocusDown = value; return element; }

        public static TElement IsFocusEngagementEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsFocusEngagementEnabled = value; return element; }

        public static TElement IsFocusEngaged<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsFocusEngaged = value; return element; }


        #endregion

        public static TElement RequiresPointer<TElement>(this TElement element, RequiresPointer value) where TElement : ElementType
        { element.RequiresPointer = value; return element; }

        public static TElement ElementSoundMode<TElement>(this TElement element, ElementSoundMode value) where TElement : ElementType
        { element.ElementSoundMode = value; return element; }

        public static TElement DefaultStyleResourceUri<TElement>(this TElement element, global::System.Uri value) where TElement : ElementType
        { element.DefaultStyleResourceUri = value; return element; }


        public static TElement BackgroundSizing<TElement>(this TElement element, BackgroundSizing sizing) where TElement : ElementType
        { element.BackgroundSizing = sizing; return element; }

        #region Events
        public static TElement AddIsEnabledChanged<TElement>(this TElement element, DependencyPropertyChangedEventHandler handler) where TElement : ElementType
        { element.IsEnabledChanged += handler; return element; }

        public static TElement AddFocusDisengaged<TElement>(this TElement element, TypedEventHandler<Control, FocusDisengagedEventArgs> handler) where TElement : ElementType
        { element.FocusDisengaged += handler; return element; }

        public static TElement AddFocusEngaged<TElement>(this TElement element, TypedEventHandler<Control, FocusEngagedEventArgs> handler) where TElement : ElementType
        { element.FocusEngaged += handler; return element; }
        #endregion
    }
}
