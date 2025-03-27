using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.FrameworkElement;

namespace P42.Uno.Markup;

public static class FrameworkElementExtensions
{
    public static TElement Name<TElement>(this TElement element, string name) where TElement :ElementType
    { element.Name = name; return element; }

    public static TElement Tag<TElement>(this TElement element, object tag) where TElement :ElementType
    { element.Tag = tag; return element; }

    public static TElement Resources<TElement>(this TElement element, params object[] objects) where TElement :ElementType
    {
        var dict = element.Resources ?? new ResourceDictionary();
        object key = null;
        foreach (var obj in objects)
        {
            if (obj is string text)
                key = text;
            else if (obj is Type type)
                key = type;
            else if (obj is IDictionary<object, object> mDict)
            {
                dict.MergedDictionaries.Add((ResourceDictionary)mDict);
                key = null;
            }
            else if (obj is Style style)
            {
                element.AddStyle(key, style);
            }
        }
        return element; 
    }

    public static TElement AddStyle<TElement>(this TElement element, Style style) where TElement : ElementType
        => element.AddStyle(null, style);

    public static TElement AddStyle<TElement>(this TElement element, object key, Style style) where TElement : ElementType
    {
        var dict = element.Resources ?? new ResourceDictionary();
        key ??= style.TargetType;
        if (style.BasedOn is null && dict.TryGetValue(key, out var xvalue))
        {
            if (xvalue is Style xstyle)
                style.BasedOn(xstyle);
            else
                dict.Add(key, style);
        }
        else
            dict.Add(key, style);
        return element;
    }

    public static TElement AddStyle<TElement>(this TElement element, string key, Type targetType, Setter first, params Setter[] setters) where TElement : ElementType
        => element.AddStyle(key, targetType, null, first, setters);

    public static TElement AddStyle<TElement>(this TElement element, Type targetType, Setter first, params Setter[] setters) where TElement : ElementType
        => element.AddStyle(null, targetType, null, first, setters);

    public static TElement AddStyle<TElement>(this TElement element, Type targetType, Style basedUpon, Setter first, params Setter[] setters) where TElement : ElementType
        => element.AddStyle(null, targetType, basedUpon, first, setters);

    public static TElement AddStyle<TElement>(this TElement element, string key, Type targetType, Style basedUpon, Setter first, params Setter[] setters) where TElement : ElementType
    {
        var style = new Style(targetType);
        if (basedUpon != null)
            style.BasedOn = basedUpon;
        style.Setters.Add(first);
        if (setters?.Any() ?? false)
        {
            foreach (var setter in setters)
                style.Setters.Add(setter);
        }
        element.AddStyle((object)key ?? targetType, style);
        return element;
    }

    public static TElement AddStyle<TElement>(this TElement element, string key, Type targetType, Style basedUpon, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
    {
        element.AddStyle(key, targetType, basedUpon, new Setter(first.Item1, first.Item2), setters?.Select(s => new Setter(s.Item1, s.Item2)).ToArray());
        return element;
    }

    public static TElement AddStyle<TElement>(this TElement element, Type targetType, Style basedUpon, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
        => element.AddStyle(null, targetType, basedUpon, first, setters);

    public static TElement AddStyle<TElement>(this TElement element, string key, Type targetType, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
        => element.AddStyle(key, targetType, null, first, setters);

    public static TElement AddStyle<TElement>(this TElement element, Type targetType, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
        => element.AddStyle(null, targetType, null, first, setters);

    public static TElement FlowDirection<TElement>(this TElement element, FlowDirection flowDirection) where TElement :ElementType
    { element.FlowDirection = flowDirection; return element; }

    public static TElement DataContext<TElement>(this TElement element, object dataContext) where TElement :ElementType
    { element.DataContext = dataContext; return element; }

    public static TElement RequestedTheme<TElement>(this TElement element, ElementTheme elementTheme) where TElement :ElementType
    { element.RequestedTheme = elementTheme; return element; }


    #region Style
    public static T Style<T>(this T element, Style style) where T :ElementType
    { element.Style = style; return element; }

    public static T Style<T>(this T element, Style<T> style) where T :ElementType
    { element.Style = style.FormsStyle; return element; }

    public static T Style<T>(this T element, DependencyProperty property, object value) where T : ElementType
    {
        element.Style = new Style<T>((property, value));
        return element;
    }

    public static T Style<T>(this T element, object resourceDictionaryEntry) where T: ElementType
    {
        if (resourceDictionaryEntry is Style style)
            element.Style(style);
        else if (resourceDictionaryEntry is Style<T> styleT)
            element.Style(styleT);
        else
            throw new InvalidCastException(
                $"Dictionary entry is of type [{resourceDictionaryEntry?.GetType()}], not Style");
        return element;
    }
    #endregion


    #region Size
    public static TElement Width<TElement>(this TElement element, double request) where TElement :ElementType
    { element.Width = request; return element; }

    public static TElement Height<TElement>(this TElement element, double request) where TElement :ElementType
    { element.Height = request; return element; }

    public static TElement MinWidth<TElement>(this TElement element, double request) where TElement :ElementType
    { element.MinWidth = request; return element; }

    public static TElement MinHeight<TElement>(this TElement element, double request) where TElement :ElementType
    { element.MinHeight = request; return element; }

    public static TElement MaxWidth<TElement>(this TElement element, double request) where TElement :ElementType
    { element.MaxWidth = request; return element; }

    public static TElement MaxHeight<TElement>(this TElement element, double request) where TElement :ElementType
    { element.MaxHeight = request; return element; }

    public static TElement Size<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
        => element.Width(widthRequest).Height(heightRequest);

    public static TElement Size<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
        => element.Width(sizeRequest).Height(sizeRequest);

    public static TElement MinSize<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
        => element.MinWidth(widthRequest).MinHeight(heightRequest);

    public static TElement MinSize<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
        => element.MinWidth(sizeRequest).MinHeight(sizeRequest);

    public static TElement MaxSize<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
        => element.MaxWidth(widthRequest).MaxHeight(heightRequest);

    public static TElement MaxSize<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
        => element.MaxWidth(sizeRequest).MaxHeight(sizeRequest);
    #endregion


    #region Alignment

    public static TElement Center<TElement>(this TElement element) where TElement :ElementType
    { 
        element.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Center; 
        element.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center; 
        return element; 
    }

    public static TElement Stretch<TElement>(this TElement element) where TElement :ElementType
    {
        element.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Stretch;
        element.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch;
        return element;
    }

    #region Vertical Alignment
    public static TElement VerticalAlignment<TElement>(this TElement element, VerticalAlignment verticalAlignment) where TElement :ElementType
    { element.VerticalAlignment = verticalAlignment; return element; }

    public static TElement Top<TElement>(this TElement element) where TElement :ElementType
    { element.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Top; return element; }

    public static TElement CenterVertical<TElement>(this TElement element) where TElement :ElementType
    { element.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Center; return element; }

    public static TElement Bottom<TElement>(this TElement element) where TElement :ElementType
    { element.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Bottom; return element; }

    public static TElement StretchVertical<TElement>(this TElement element) where TElement :ElementType
    { element.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Stretch; return element; }

    #endregion

    #region Horizontal Alignment
    public static TElement HorizontalAlignment<TElement>(this TElement element, HorizontalAlignment horizontalAlignment) where TElement :ElementType
    { element.HorizontalAlignment = horizontalAlignment; return element; }

    public static TElement Left<TElement>(this TElement element) where TElement :ElementType
    { element.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Left; return element; }

    public static TElement CenterHorizontal<TElement>(this TElement element) where TElement :ElementType
    { element.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center; return element; }

    public static TElement Right<TElement>(this TElement element) where TElement :ElementType
    { element.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Right; return element; }

    public static TElement StretchHorizontal<TElement>(this TElement element) where TElement :ElementType
    { element.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch; return element; }
    #endregion


    #endregion


    #region Margin

    public static TElement Margin<TElement>(this TElement element, double value) where TElement :ElementType
    { element.Margin = new Thickness(value); return element; }

    public static TElement Margin<TElement>(this TElement element, double horizontal, double vertical) where TElement :ElementType
    { element.Margin = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

    public static TElement Margin<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement :ElementType
    { element.Margin = new Thickness(left, top, right, bottom); return element; }

    public static TElement Margin<TElement>(this TElement element, Thickness margin) where TElement :ElementType
    { element.Margin = margin; return element; }

    #endregion

    public static TElement Language<TElement>(this TElement element, string language) where TElement :ElementType
    { element.Language = language; return element; }


    #region Focus
    public static TElement FocusVisualSecondaryThickness<TElement>(this TElement element, Thickness thickness) where TElement :ElementType
    { element.FocusVisualSecondaryThickness = thickness; return element; }

    public static TElement FocusVisualSecondaryBrush<TElement>(this TElement element, Brush brush) where TElement :ElementType
    { element.FocusVisualSecondaryBrush = brush; return element; }

    public static TElement FocusVisualPrimaryThickness<TElement>(this TElement element, Thickness thickness) where TElement :ElementType
    { element.FocusVisualPrimaryThickness = thickness; return element; }

    public static TElement FocusVisualPrimaryBrush<TElement>(this TElement element, Brush brush) where TElement :ElementType
    { element.FocusVisualPrimaryBrush = brush; return element; }

    public static TElement FocusVisualMargin<TElement>(this TElement element, Thickness thickness) where TElement :ElementType
    { element.FocusVisualMargin = thickness; return element; }

    public static TElement AllowFocusWhenDisabled<TElement>(this TElement element, bool allow = true) where TElement :ElementType
    { element.AllowFocusWhenDisabled = allow; return element; }

    public static TElement AllowFocusOnInteraction<TElement>(this TElement element, bool allow = true) where TElement :ElementType
    { element.AllowFocusOnInteraction = allow; return element; }

    #endregion


    #region Events
    public static TElement AddLayoutUpdatedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.LayoutUpdated += handler; return element; }

    public static TElement AddLoadedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { element.Loaded += handler; return element; }

    public static TElement AddSizeChangedHandler<TElement>(this TElement element, SizeChangedEventHandler handler) where TElement : ElementType
    { element.SizeChanged += handler; return element; }

    public static TElement AddUnloadedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { element.Unloaded += handler; return element; }


    public static TElement AddDataContextChangedHandler<TElement>(this TElement element, TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> handler) where TElement : ElementType
    { element.DataContextChanged += handler; return element; }

    public static TElement AddLoadingHandler<TElement>(this TElement element, TypedEventHandler<FrameworkElement, object> handler) where TElement : ElementType
    { element.Loading += handler; return element; }

    public static TElement AddActualThemeChangedHandler<TElement>(this TElement element, TypedEventHandler<FrameworkElement, object> handler) where TElement : ElementType
    { element.ActualThemeChanged += handler; return element; }

    public static TElement AddEffectiveViewportChangedHandler<TElement>(this TElement element, TypedEventHandler<FrameworkElement, EffectiveViewportChangedEventArgs> handler) where TElement : ElementType
    { element.EffectiveViewportChanged += handler; return element; }

    #endregion



    #region Special Bindings

    #region BindBorder
    public static TElement BindBorder<TElement>(this TElement target, Control source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
    {
        if (typeof(ElementType).GetBorderDependencyProperty(nameof(Control.BorderBrushProperty)) is { } borderBrushProperty)
            target.Bind(borderBrushProperty, source, nameof(Control.BorderBrush), bindingMode);
        if (typeof(ElementType).GetBorderDependencyProperty(nameof(Control.BorderThicknessProperty)) is { } borderThicknessProperty)
            target.Bind(borderThicknessProperty, source, nameof(Control.BorderThickness), bindingMode);
        if (typeof(ElementType).GetBorderDependencyProperty(nameof(Control.CornerRadiusProperty)) is { } cornerRadiusProperty)
            target.Bind(cornerRadiusProperty, source, nameof(Control.CornerRadius), bindingMode);
        return target;
    }

    private static DependencyProperty GetBorderDependencyProperty(this Type type, string propertyName) 
    { 
        switch (propertyName)
        {
            case nameof(Control.BorderBrushProperty):
                switch (type.Name)
                {
                    case nameof(Control):
                        return Control.BorderBrushProperty;
                    case nameof(ContentPresenter):
                        return ContentPresenter.BorderBrushProperty;
                    case nameof(Border):
                        return Border.BorderBrushProperty;
                    case nameof(Grid):
                        return Grid.BorderBrushProperty;
                    case nameof(RelativePanel):
                        return RelativePanel.BorderBrushProperty;
                    case nameof(StackPanel):
                        return StackPanel.BorderBrushProperty;
                }
                break;
            case nameof(Control.BorderThickness):
                switch (type.Name)
                {
                    case nameof(Control):
                        return Control.BorderThicknessProperty;
                    case nameof(ContentPresenter):
                        return ContentPresenter.BorderThicknessProperty;
                    case nameof(Border):
                        return Border.BorderThicknessProperty;
                    case nameof(Grid):
                        return Grid.BorderThicknessProperty;
                    case nameof(RelativePanel):
                        return RelativePanel.BorderThicknessProperty;
                    case nameof(StackPanel):
                        return StackPanel.BorderThicknessProperty;
                }
                break;
            case nameof(Control.CornerRadius):
                switch (type.Name)
                {
                    case nameof(Control):
                        return Control.CornerRadiusProperty;
                    case nameof(ContentPresenter):
                        return ContentPresenter.CornerRadiusProperty;
                    case nameof(Border):
                        return Border.CornerRadiusProperty;
                    case nameof(Grid):
                        return Grid.CornerRadiusProperty;
                    case nameof(RelativePanel):
                        return RelativePanel.CornerRadiusProperty;
                    case nameof(StackPanel):
                        return StackPanel.CornerRadiusProperty;
                }
                break;
        }
        return null;
    }
    #endregion

    #endregion

}