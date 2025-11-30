using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.Control;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ControlExtensions
{


    #region Font Properties

    #region Workaround Binding
    public static TElement BindFont<TElement>(this TElement target, Control source, BindingMode bindingMode = BindingMode.OneWay, object? except = null) where TElement : ElementType
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(Control.CharacterSpacing)))
            target.AltBind(ElementType.CharacterSpacingProperty, source, Control.CharacterSpacingProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
            target.AltBind(ElementType.FontFamilyProperty, source, Control.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
            target.AltBind(ElementType.FontSizeProperty, source, Control.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
            target.AltBind(ElementType.FontStretchProperty, source, Control.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
            target.AltBind(ElementType.FontStyleProperty, source, Control.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
            target.AltBind(ElementType.FontWeightProperty, source, Control.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
            target.AltBind(ElementType.ForegroundProperty, source, Control.ForegroundProperty, bindingMode);
        return target;
    }

    public static TElement BindTextProperties<TElement>(this TElement target, Control source, BindingMode bindingMode = BindingMode.OneWay, object? except = null) where TElement : ElementType
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
            target.AltBind(ElementType.IsTextScaleFactorEnabledProperty, source, Control.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }


    public static TElement BindFont<TElement>(this TElement target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object? except = null) where TElement : ElementType
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
            target.AltBind(ElementType.FontFamilyProperty, source, TextBlock.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
            target.AltBind(ElementType.FontSizeProperty, source, TextBlock.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
            target.AltBind(ElementType.FontStretchProperty, source, TextBlock.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
            target.AltBind(ElementType.FontStyleProperty, source, TextBlock.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
            target.AltBind(ElementType.FontWeightProperty, source, TextBlock.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
            target.AltBind(ElementType.ForegroundProperty, source, TextBlock.ForegroundProperty, bindingMode);
        return target;
    }

    public static TElement BindTextProperties<TElement>(this TElement target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object? except = null) where TElement : ElementType
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabledProperty)))
            target.AltBind(ElementType.IsTextScaleFactorEnabledProperty, source, TextBlock.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }



    public static TElement BindFont<TElement>(this TElement target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object? except = null) where TElement : ElementType
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
            target.AltBind(ElementType.FontFamilyProperty, source, ContentPresenter.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
            target.AltBind(ElementType.FontSizeProperty, source, ContentPresenter.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
            target.AltBind(ElementType.FontStretchProperty, source, ContentPresenter.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
            target.AltBind(ElementType.FontStyleProperty, source, ContentPresenter.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
            target.AltBind(ElementType.FontWeightProperty, source, ContentPresenter.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
            target.AltBind(ElementType.ForegroundProperty, source, ContentPresenter.ForegroundProperty, bindingMode);

        return target;
    }

    public static TElement BindTextProperties<TElement>(this TElement target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object? except = null) where TElement : ElementType
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
            target.AltBind(ElementType.IsTextScaleFactorEnabledProperty, source, ContentPresenter.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }
    #endregion

    #endregion


    #region Border Properties


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

    #endregion

}
