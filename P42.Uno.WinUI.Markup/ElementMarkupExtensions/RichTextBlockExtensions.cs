using ElementType = Microsoft.UI.Xaml.Controls.RichTextBlock;
using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class RichTextEditExtensions
{

    #region Text/Font Workaround Binding
    public static ElementType BindFont(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
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

    public static ElementType BindTextProperties(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
            target.AltBind(ElementType.IsTextScaleFactorEnabledProperty, source, Control.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }

    public static ElementType BindFont(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
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

    public static ElementType BindTextProperties(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabled)))
            target.AltBind(ElementType.IsTextScaleFactorEnabledProperty, source, TextBlock.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.LineHeightProperty)))
            target.AltBind(ElementType.LineHeightProperty, source, TextBlock.LineHeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.LineStackingStrategyProperty)))
            target.AltBind(ElementType.LineStackingStrategyProperty, source, TextBlock.LineStackingStrategyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.MaxLinesProperty)))
            target.AltBind(ElementType.MaxLinesProperty, source, TextBlock.MaxLinesProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.TextLineBoundsProperty)))
            target.AltBind(ElementType.TextLineBoundsProperty, source, TextBlock.TextLineBoundsProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.TextWrappingProperty)))
            target.AltBind(ElementType.TextWrappingProperty, source, TextBlock.TextWrappingProperty, bindingMode);

        return target;
    }


    public static ElementType BindFont(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
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

    public static ElementType BindTextProperties(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
            target.AltBind(ElementType.IsTextScaleFactorEnabledProperty, source, ContentPresenter.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.LineHeightProperty)))
            target.AltBind(ElementType.LineHeightProperty, source, ContentPresenter.LineHeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.LineStackingStrategyProperty)))
            target.AltBind(ElementType.LineStackingStrategyProperty, source, ContentPresenter.LineStackingStrategyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.MaxLinesProperty)))
            target.AltBind(ElementType.MaxLinesProperty, source, ContentPresenter.MaxLinesProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextLineBoundsProperty)))
            target.AltBind(ElementType.TextLineBoundsProperty, source, ContentPresenter.TextLineBoundsProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextWrappingProperty)))
            target.AltBind(ElementType.TextWrappingProperty, source, ContentPresenter.TextWrappingProperty, bindingMode);

        return target;
    }

    #endregion

}
