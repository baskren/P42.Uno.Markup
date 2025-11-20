using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.Border;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class BorderClassExtensions
{


    public static ElementType BindNullCollapse(this ElementType element)
    {
        return element.AltBind(UIElement.VisibilityProperty, element, ElementType.ChildProperty,
            convert: (UIElement? child) => child is null ? Visibility.Collapsed:Visibility.Visible);
    }

    #region BindBorder

    public static Border BindBorder(this Border target, Control source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.AltBind(ElementType.BorderBrushProperty, source, Control.BorderBrushProperty, bindingMode);
        target.AltBind(ElementType.BorderThicknessProperty, source, Control.BorderThicknessProperty, bindingMode);
        target.AltBind(ElementType.CornerRadiusProperty, source, Control.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.AltBind(ElementType.BorderBrushProperty, source, ContentPresenter.BorderBrushProperty, bindingMode);
        target.AltBind(ElementType.BorderThicknessProperty, source, ContentPresenter.BorderThicknessProperty, bindingMode);
        target.AltBind(ElementType.CornerRadiusProperty, source, ContentPresenter.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, Border source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.AltBind(ElementType.BorderBrushProperty, source, Border.BorderBrushProperty, bindingMode);
        target.AltBind(ElementType.BorderThicknessProperty, source, Border.BorderThicknessProperty, bindingMode);
        target.AltBind(ElementType.CornerRadiusProperty, source, Border.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, Grid source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.AltBind(ElementType.BorderBrushProperty, source, Grid.BorderBrushProperty, bindingMode);
        target.AltBind(ElementType.BorderThicknessProperty, source, Grid.BorderThicknessProperty, bindingMode);
        target.AltBind(ElementType.CornerRadiusProperty, source, Grid.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, RelativePanel source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.AltBind(ElementType.BorderBrushProperty, source, RelativePanel.BorderBrushProperty, bindingMode);
        target.AltBind(ElementType.BorderThicknessProperty, source, RelativePanel.BorderThicknessProperty, bindingMode);
        target.AltBind(ElementType.CornerRadiusProperty, source, RelativePanel.CornerRadiusProperty, bindingMode);
        return target;
    }
    public static Border BindBorder(this Border target, StackPanel source, BindingMode bindingMode = BindingMode.OneWay) 
    {
        target.AltBind(ElementType.BorderBrushProperty, source, StackPanel.BorderBrushProperty, bindingMode);
        target.AltBind(ElementType.BorderThicknessProperty, source, StackPanel.BorderThicknessProperty, bindingMode);
        target.AltBind(ElementType.CornerRadiusProperty, source, StackPanel.CornerRadiusProperty, bindingMode);
        return target;
    }
    #endregion


}
