using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.Controls.TextBlock;

// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class TextBlockExtensions
{

    extension(ElementType element)
    {
        public ElementType BindNullOrEmptyCollapse()
        {
            return element.AltBind(UIElement.VisibilityProperty, element, ElementType.TextProperty,
                convert: (string? text) => !string.IsNullOrEmpty(text) ? Visibility.Visible : Visibility.Collapsed);
        }
    }



}
