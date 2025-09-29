using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using P42.Utils.Uno;
using Windows.UI;
using ElementType = Microsoft.UI.Xaml.Controls.Border;

namespace P42.Uno.Markup;

public static class BorderClassExtensions
{


    public static ElementType BindNullCollapse(this ElementType element)
    {
        return element.BindX(UIElement.VisibilityProperty, element, nameof(Border.Child),
            convert: (UIElement child) => child is null ? Visibility.Collapsed:Visibility.Visible);
    }

    #region BindBorder

    public static Border BindBorder(this Border target, Control source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.WBind(ElementType.BorderBrushProperty, source, Control.BorderBrushProperty, bindingMode);
        target.WBind(ElementType.BorderThicknessProperty, source, Control.BorderThicknessProperty, bindingMode);
        target.WBind(ElementType.CornerRadiusProperty, source, Control.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.WBind(ElementType.BorderBrushProperty, source, ContentPresenter.BorderBrushProperty, bindingMode);
        target.WBind(ElementType.BorderThicknessProperty, source, ContentPresenter.BorderThicknessProperty, bindingMode);
        target.WBind(ElementType.CornerRadiusProperty, source, ContentPresenter.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, Border source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.WBind(ElementType.BorderBrushProperty, source, Border.BorderBrushProperty, bindingMode);
        target.WBind(ElementType.BorderThicknessProperty, source, Border.BorderThicknessProperty, bindingMode);
        target.WBind(ElementType.CornerRadiusProperty, source, Border.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, Grid source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.WBind(ElementType.BorderBrushProperty, source, Grid.BorderBrushProperty, bindingMode);
        target.WBind(ElementType.BorderThicknessProperty, source, Grid.BorderThicknessProperty, bindingMode);
        target.WBind(ElementType.CornerRadiusProperty, source, Grid.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, RelativePanel source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.WBind(ElementType.BorderBrushProperty, source, RelativePanel.BorderBrushProperty, bindingMode);
        target.WBind(ElementType.BorderThicknessProperty, source, RelativePanel.BorderThicknessProperty, bindingMode);
        target.WBind(ElementType.CornerRadiusProperty, source, RelativePanel.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, StackPanel source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.WBind(ElementType.BorderBrushProperty, source, StackPanel.BorderBrushProperty, bindingMode);
        target.WBind(ElementType.BorderThicknessProperty, source, StackPanel.BorderThicknessProperty, bindingMode);
        target.WBind(ElementType.CornerRadiusProperty, source, StackPanel.CornerRadiusProperty, bindingMode);
        return target;
    }
    #endregion


}
