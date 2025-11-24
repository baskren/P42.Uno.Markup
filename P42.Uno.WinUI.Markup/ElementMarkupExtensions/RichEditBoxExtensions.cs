using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.RichEditBox;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class RichEditBoxExtensions
{

    #region Text/Font Workaround Binding
    public static ElementType BindFont(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(Control.CharacterSpacing)))
            target.AltBind(Control.CharacterSpacingProperty, source, Control.CharacterSpacingProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
            target.AltBind(Control.FontFamilyProperty, source, Control.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
            target.AltBind(Control.FontSizeProperty, source, Control.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
            target.AltBind(Control.FontStretchProperty, source, Control.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
            target.AltBind(Control.FontStyleProperty, source, Control.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
            target.AltBind(Control.FontWeightProperty, source, Control.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
            target.AltBind(Control.ForegroundProperty, source, Control.ForegroundProperty, bindingMode);
        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
            target.AltBind(Control.IsTextScaleFactorEnabledProperty, source, Control.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }

    public static ElementType BindFont(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
            target.AltBind(Control.FontFamilyProperty, source, TextBlock.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
            target.AltBind(Control.FontSizeProperty, source, TextBlock.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
            target.AltBind(Control.FontStretchProperty, source, TextBlock.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
            target.AltBind(Control.FontStyleProperty, source, TextBlock.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
            target.AltBind(Control.FontWeightProperty, source, TextBlock.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
            target.AltBind(Control.ForegroundProperty, source, TextBlock.ForegroundProperty, bindingMode);
        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabledProperty)))
            target.AltBind(Control.IsTextScaleFactorEnabledProperty, source, TextBlock.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.TextWrappingProperty)))
            target.AltBind(ElementType.TextWrappingProperty, source, TextBlock.TextWrappingProperty, bindingMode);

        return target;
    }


    public static ElementType BindFont(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
            target.AltBind(Control.FontFamilyProperty, source, ContentPresenter.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
            target.AltBind(Control.FontSizeProperty, source, ContentPresenter.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
            target.AltBind(Control.FontStretchProperty, source, ContentPresenter.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
            target.AltBind(Control.FontStyleProperty, source, ContentPresenter.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
            target.AltBind(Control.FontWeightProperty, source, ContentPresenter.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
            target.AltBind(Control.ForegroundProperty, source, ContentPresenter.ForegroundProperty, bindingMode);

        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object? except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFont(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
            target.AltBind(Control.IsTextScaleFactorEnabledProperty, source, ContentPresenter.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextWrappingProperty)))
            target.AltBind(ElementType.TextWrappingProperty, source, ContentPresenter.TextWrappingProperty, bindingMode);

        return target;
    }

    #endregion


}
