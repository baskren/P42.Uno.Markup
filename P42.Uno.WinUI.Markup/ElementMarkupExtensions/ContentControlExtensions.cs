using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.ContentControl;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ContentControlExtensions
{

    public static TElement BindNullCollapseX<TElement>(this TElement element) where TElement : ElementType
    {
        return element.AltBind(UIElement.VisibilityProperty, element, ElementType.ContentProperty,
            convert: (object? content) => content != null ? Visibility.Visible : Visibility.Collapsed);
    }
}
