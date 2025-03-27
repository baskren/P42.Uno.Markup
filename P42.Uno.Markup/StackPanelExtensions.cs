using System;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.StackPanel ;

namespace P42.Uno.Markup;

public static class StackPanelExtensions
{
    #region Orientation
    public static TElement Orientation<TElement>(this TElement element, Orientation orientation) where TElement : ElementType
    { element.Orientation = orientation; return element; }

    public static TElement Horizontal<TElement>(this TElement element) where TElement : ElementType
    { element.Orientation = Microsoft.UI.Xaml.Controls.Orientation.Horizontal; return element; }

    public static TElement Vertical<TElement>(this TElement element) where TElement : ElementType
    { element.Orientation = Microsoft.UI.Xaml.Controls.Orientation.Vertical; return element; }
    #endregion


    public static TElement RegularScrollSnapPoints<TElement>(this TElement element, bool regular = true) where TElement : ElementType
    { element.AreScrollSnapPointsRegular = regular; return element; }


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


    #region CornerRadius
    public static TElement CornerRadius<TElement>(this TElement element, double value) where TElement : ElementType
    { element.CornerRadius = new CornerRadius(value); return element; }

    public static TElement CornerRadius<TElement>(this TElement element, double topLeft, double topRight, double bottomRight, double bottomLeft) where TElement : ElementType
    { element.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft); return element; }

    public static TElement CornerRadius<TElement>(this TElement element, CornerRadius padding) where TElement : ElementType
    { element.CornerRadius = padding; return element; }
    #endregion


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

    public static TElement BorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
    { element.BorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

    public static TElement BorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
    { element.BorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
    #endregion

    /*
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
    public static TElement BindBorder<TElement>(this TElement target, Grid source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
    {
        target.Bind(ElementType.BorderBrushProperty, source, nameof(Grid.BorderBrush), bindingMode);
        target.Bind(ElementType.BorderThicknessProperty, source, nameof(Grid.BorderThickness), bindingMode);
        target.Bind(ElementType.CornerRadiusProperty, source, nameof(Grid.CornerRadius), bindingMode);
        return target;
    }
    public static TElement BindBorder<TElement>(this TElement target, RelativePanel source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
    {
        target.Bind(ElementType.BorderBrushProperty, source, nameof(RelativePanel.BorderBrush), bindingMode);
        target.Bind(ElementType.BorderThicknessProperty, source, nameof(RelativePanel.BorderThickness), bindingMode);
        target.Bind(ElementType.CornerRadiusProperty, source, nameof(RelativePanel.CornerRadius), bindingMode);
        return target;
    }
    public static TElement BindBorder<TElement>(this TElement target, StackPanel source, BindingMode bindingMode = BindingMode.OneWay) where TElement : ElementType
    {
        target.Bind(ElementType.BorderBrushProperty, source, nameof(StackPanel.BorderBrush), bindingMode);
        target.Bind(ElementType.BorderThicknessProperty, source, nameof(StackPanel.BorderThickness), bindingMode);
        target.Bind(ElementType.CornerRadiusProperty, source, nameof(StackPanel.CornerRadius), bindingMode);
        return target;
    }
    #endregion
    */


    public static TElement Spacing<TElement>(this TElement element, double value) where TElement : ElementType
    { element.Spacing = value; return element; }

    public static TElement BackgroundSizing<TElement>(this TElement element, BackgroundSizing value) where TElement : ElementType
    { element.BackgroundSizing = value; return element; }


    #region Events
    public static TElement AddHorizontalSnapPointsChangedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.HorizontalSnapPointsChanged += handler; return element; }

    public static TElement AddVerticalSnapPointsChangedHandler<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
    { element.VerticalSnapPointsChanged += handler; return element; }
    #endregion
}
