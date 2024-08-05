//NavigationViewItem

using ElementType = Microsoft.UI.Xaml.Controls.NavigationViewItemBase;

namespace P42.Uno.Markup
{
    public static class NavigationViewItemBaseExtensions
    {
        public static TElement IsSelected<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSelected = value; return element; }


    }
}
