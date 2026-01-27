using ElementType = Microsoft.UI.Xaml.Controls.NavigationView;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class NavigationViewExtensions
{
    #region Properties


    /// <summary>
    /// Fluent setter for NavigationView menu items
    /// </summary>
    /// <param name="element"></param>
    /// <param name="items"></param>
    /// <typeparam name="TElement"></typeparam>
    /// <returns></returns>
    public static TElement NewMenuItems<TElement>(this TElement element, params object[] items) where TElement : ElementType
    {
        element.MenuItems.Clear();
        return element.MenuItems(items);
    }
    #endregion



}
