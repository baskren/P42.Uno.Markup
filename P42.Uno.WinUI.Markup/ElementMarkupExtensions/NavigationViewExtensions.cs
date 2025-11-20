using ElementType = Microsoft.UI.Xaml.Controls.NavigationView;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class NavigationViewExtensions
{
    #region Properties



    public static TElement NewMenuItemsX<TElement>(this TElement element, params object[] items) where TElement : ElementType
    {
        element.MenuItems.Clear();
        return element.MenuItems(items);
    }
    #endregion



}
