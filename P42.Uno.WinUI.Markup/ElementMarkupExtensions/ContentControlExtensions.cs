using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media.Animation;
using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.ContentControl;

namespace P42.Uno.Markup;

public static class ContentControlExtensions
{

    public static TElement BindNullCollapseX<TElement>(this TElement element) where TElement : ElementType
    {
        return element.WBind(UIElement.VisibilityProperty, element, ContentControl.ContentProperty,
            convert: (object content) => content != null ? Visibility.Visible : Visibility.Collapsed);
    }
}
