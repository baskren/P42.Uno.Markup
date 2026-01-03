using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.ContentPresenter;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ContentPresenterExtensions
{
    #region Binding
    public static TElement BindNullCollapse<TElement>(this TElement element) where TElement : ElementType
    {
        return element.AltBind(UIElement.VisibilityProperty, element, ContentPresenter.ContentProperty,
            convert: (object? content) => content != null? Visibility.Visible : Visibility.Collapsed);
    }



    #endregion


}
