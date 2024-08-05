//NavigationViewItem

using ElementType = Microsoft.UI.Xaml.Controls.Primitives.SelectorItem;

namespace P42.Uno.Markup
{
    public static class SelectorItemExtensions
    {
        public static TElement IsSelected<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSelected = value; return element; }

    }
}
