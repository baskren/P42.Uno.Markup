using Microsoft.UI.Xaml;
using ElementType = Microsoft.UI.Xaml.Controls.UserControl;

namespace P42.Uno.Markup;
public static class UserControlExtensions
{
    public static TElement Content<TElement>(this TElement element, UIElement value) where TElement : ElementType
    { element.Content = value; return element; }
}
