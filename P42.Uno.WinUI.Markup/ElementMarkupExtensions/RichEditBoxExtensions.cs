using System;
using System.Xml.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using P42.Utils.Uno;
using Windows.Foundation;
using Windows.UI;
using ElementType = Microsoft.UI.Xaml.Controls.RichEditBox;

namespace P42.Uno.Markup;

public static class RichEditBoxExtensions
{

    #region Text/Font Workaround Binding
    public static ElementType BindFontX(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(Control.CharacterSpacing)))
            target.WBind(Control.CharacterSpacingProperty, source, Control.CharacterSpacingProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
            target.WBind(Control.FontFamilyProperty, source, Control.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
            target.WBind(Control.FontSizeProperty, source, Control.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
            target.WBind(Control.FontStretchProperty, source, Control.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
            target.WBind(Control.FontStyleProperty, source, Control.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
            target.WBind(Control.FontWeightProperty, source, Control.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
            target.WBind(Control.ForegroundProperty, source, Control.ForegroundProperty, bindingMode);
        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFontX(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
            target.WBind(Control.IsTextScaleFactorEnabledProperty, source, Control.IsTextScaleFactorEnabledProperty, bindingMode);

        return target;
    }

    public static ElementType BindFontX(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
            target.WBind(Control.FontFamilyProperty, source, TextBlock.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
            target.WBind(Control.FontSizeProperty, source, TextBlock.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
            target.WBind(Control.FontStretchProperty, source, TextBlock.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
            target.WBind(Control.FontStyleProperty, source, TextBlock.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
            target.WBind(Control.FontWeightProperty, source, TextBlock.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
            target.WBind(Control.ForegroundProperty, source, TextBlock.ForegroundProperty, bindingMode);
        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFontX(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabledProperty)))
            target.WBind(Control.IsTextScaleFactorEnabledProperty, source, TextBlock.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(TextBlock.TextWrappingProperty)))
            target.WBind(ElementType.TextWrappingProperty, source, TextBlock.TextWrappingProperty, bindingMode);

        return target;
    }


    public static ElementType BindFontX(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
            target.WBind(Control.FontFamilyProperty, source, ContentPresenter.FontFamilyProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
            target.WBind(Control.FontSizeProperty, source, ContentPresenter.FontSizeProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
            target.WBind(Control.FontStretchProperty, source, ContentPresenter.FontStretchProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
            target.WBind(Control.FontStyleProperty, source, ContentPresenter.FontStyleProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
            target.WBind(Control.FontWeightProperty, source, ContentPresenter.FontWeightProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
            target.WBind(Control.ForegroundProperty, source, ContentPresenter.ForegroundProperty, bindingMode);

        return target;
    }

    public static ElementType BindTextProperties(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
    {
        var excepts = InternalHelpers.GetExcepts(except);
        target.BindFontX(source, bindingMode, excepts);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
            target.WBind(Control.IsTextScaleFactorEnabledProperty, source, ContentPresenter.IsTextScaleFactorEnabledProperty, bindingMode);
        if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextWrappingProperty)))
            target.WBind(ElementType.TextWrappingProperty, source, ContentPresenter.TextWrappingProperty, bindingMode);

        return target;
    }

    #endregion


}
