using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI.Text;
using ElementType = Microsoft.UI.Xaml.Controls.RichTextBlock;
using P42.Utils.Uno;

namespace P42.Uno.Markup;

public static class RichTextEditExtensions
{

    #region Text/Font Workaround Binding
    public static ElementType BindFontX(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(Control.CharacterSpacing)))
            target.WBind(ElementType.CharacterSpacingProperty, source, Control.CharacterSpacingProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
            target.WBind(ElementType.FontFamilyProperty, source, Control.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
            target.WBind(ElementType.FontSizeProperty, source, Control.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
            target.WBind(ElementType.FontStretchProperty, source, Control.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
            target.WBind(ElementType.FontStyleProperty, source, Control.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
            target.WBind(ElementType.FontWeightProperty, source, Control.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
            target.WBind(ElementType.ForegroundProperty, source, Control.ForegroundProperty, bindingMode);
        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFontX(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
            target.WBind(ElementType.IsTextScaleFactorEnabledProperty, source, Control.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }

    public static ElementType BindFontX(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
            target.WBind(ElementType.FontFamilyProperty, source, TextBlock.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
            target.WBind(ElementType.FontSizeProperty, source, TextBlock.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
            target.WBind(ElementType.FontStretchProperty, source, TextBlock.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
            target.WBind(ElementType.FontStyleProperty, source, TextBlock.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
            target.WBind(ElementType.FontWeightProperty, source, TextBlock.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
            target.WBind(ElementType.ForegroundProperty, source, TextBlock.ForegroundProperty, bindingMode);
        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFontX(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabled)))
            target.WBind(ElementType.IsTextScaleFactorEnabledProperty, source, TextBlock.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.LineHeightProperty)))
            target.WBind(ElementType.LineHeightProperty, source, TextBlock.LineHeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.LineStackingStrategyProperty)))
            target.WBind(ElementType.LineStackingStrategyProperty, source, TextBlock.LineStackingStrategyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.MaxLinesProperty)))
            target.WBind(ElementType.MaxLinesProperty, source, TextBlock.MaxLinesProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.TextLineBoundsProperty)))
            target.WBind(ElementType.TextLineBoundsProperty, source, TextBlock.TextLineBoundsProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.TextWrappingProperty)))
            target.WBind(ElementType.TextWrappingProperty, source, TextBlock.TextWrappingProperty, bindingMode);

        return target;
    }


    public static ElementType BindFontX(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
            target.WBind(ElementType.FontFamilyProperty, source, ContentPresenter.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
            target.WBind(ElementType.FontSizeProperty, source, ContentPresenter.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
            target.WBind(ElementType.FontStretchProperty, source, ContentPresenter.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
            target.WBind(ElementType.FontStyleProperty, source, ContentPresenter.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
            target.WBind(ElementType.FontWeightProperty, source, ContentPresenter.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
            target.WBind(ElementType.ForegroundProperty, source, ContentPresenter.ForegroundProperty, bindingMode);

        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFontX(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
            target.WBind(ElementType.IsTextScaleFactorEnabledProperty, source, ContentPresenter.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.LineHeightProperty)))
            target.WBind(ElementType.LineHeightProperty, source, ContentPresenter.LineHeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.LineStackingStrategyProperty)))
            target.WBind(ElementType.LineStackingStrategyProperty, source, ContentPresenter.LineStackingStrategyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.MaxLinesProperty)))
            target.WBind(ElementType.MaxLinesProperty, source, ContentPresenter.MaxLinesProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextLineBoundsProperty)))
            target.WBind(ElementType.TextLineBoundsProperty, source, ContentPresenter.TextLineBoundsProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextWrappingProperty)))
            target.WBind(ElementType.TextWrappingProperty, source, ContentPresenter.TextWrappingProperty, bindingMode);

        return target;
    }

    #endregion

}
