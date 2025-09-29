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
    public static TElement ResourcesX<TElement>(this TElement element, params object[] objects) where TElement :ElementType
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
                element.AddStyleX(key, style);
            }
        }
        return element; 
    }

    public static TElement AddStyleX<TElement>(this TElement element, Style style) where TElement : ElementType
        => element.AddStyleX(null, style);

    public static TElement AddStyleX<TElement>(this TElement element, object key, Style style) where TElement : ElementType
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

    public static TElement AddStyleX<TElement>(this TElement element, string key, Type targetType, Setter first, params Setter[] setters) where TElement : ElementType
        => element.AddStyleX(key, targetType, null, first, setters);

    public static TElement AddStyleX<TElement>(this TElement element, Type targetType, Setter first, params Setter[] setters) where TElement : ElementType
        => element.AddStyleX(null, targetType, null, first, setters);

    public static TElement AddStyleX<TElement>(this TElement element, Type targetType, Style basedUpon, Setter first, params Setter[] setters) where TElement : ElementType
        => element.AddStyleX(null, targetType, basedUpon, first, setters);

    public static TElement AddStyleX<TElement>(this TElement element, string key, Type targetType, Style basedUpon, Setter first, params Setter[] setters) where TElement : ElementType
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
        element.AddStyleX((object)key ?? targetType, style);
        return element;
    }

    public static TElement AddStyleX<TElement>(this TElement element, string key, Type targetType, Style basedUpon, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
    {
        element.AddStyleX(key, targetType, basedUpon, new Setter(first.Item1, first.Item2), setters?.Select(s => new Setter(s.Item1, s.Item2)).ToArray());
        return element;
    }

    public static TElement AddStyleX<TElement>(this TElement element, Type targetType, Style basedUpon, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
        => element.AddStyleX(null, targetType, basedUpon, first, setters);

    public static TElement AddStyleX<TElement>(this TElement element, string key, Type targetType, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
        => element.AddStyleX(key, targetType, null, first, setters);

    public static TElement AddStyleX<TElement>(this TElement element, Type targetType, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) where TElement : ElementType
        => element.AddStyleX(null, targetType, null, first, setters);


    #region Style
    public static T StyleX<T>(this T element, Style<T> style) where T :ElementType
    { element.Style = style.FormsStyle; return element; }

    public static T StyleX<T>(this T element, DependencyProperty property, object value) where T : ElementType
    {
        element.Style = new Style<T>((property, value));
        return element;
    }

    public static T StyleX<T>(this T element, object resourceDictionaryEntry) where T: ElementType
    {
        if (resourceDictionaryEntry is Style style)
            element.StyleX(style);
        else if (resourceDictionaryEntry is Style<T> styleT)
            element.StyleX(styleT);
        else
            throw new InvalidCastException(
                $"Dictionary entry is of type [{resourceDictionaryEntry?.GetType()}], not Style");
        return element;
    }
    #endregion


    #region Size
    public static TElement SizeX<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
        => element.Width(widthRequest).Height(heightRequest);

    public static TElement SizeX<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
        => element.Width(sizeRequest).Height(sizeRequest);

    public static TElement MinSizeX<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
        => element.MinWidth(widthRequest).MinHeight(heightRequest);

    public static TElement MinSizeX<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
        => element.MinWidth(sizeRequest).MinHeight(sizeRequest);

    public static TElement MaxSizeX<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
        => element.MaxWidth(widthRequest).MaxHeight(heightRequest);

    public static TElement MaxSizeX<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
        => element.MaxWidth(sizeRequest).MaxHeight(sizeRequest);
    #endregion



    #region Special Bindings

    #region BindBorder
    public static TElement BindBorderX<TElement>(this TElement target, Control source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
    {
        if (typeof(ElementType).GetBorderDependencyProperty(nameof(Control.BorderBrushProperty)) is { } borderBrushProperty)
            target.BindX(borderBrushProperty, source, nameof(Control.BorderBrush), bindingMode);
        if (typeof(ElementType).GetBorderDependencyProperty(nameof(Control.BorderThicknessProperty)) is { } borderThicknessProperty)
            target.BindX(borderThicknessProperty, source, nameof(Control.BorderThickness), bindingMode);
        if (typeof(ElementType).GetBorderDependencyProperty(nameof(Control.CornerRadiusProperty)) is { } cornerRadiusProperty)
            target.BindX(cornerRadiusProperty, source, nameof(Control.CornerRadius), bindingMode);
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
