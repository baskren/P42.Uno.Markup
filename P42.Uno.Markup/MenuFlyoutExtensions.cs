using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.MenuFlyout;

namespace P42.Uno.Markup;
public static class MenuFlyoutExtensions
{
    #region Items
    public static ElementType AddItems(this ElementType panel, params MenuFlyoutItemBase[] children)
    {
        if (children != null)
        {
            foreach (var child in children)
            {
                panel.Items.Add(child);
            }
        }
        return panel;
    }

    public static ElementType Items(this ElementType panel, params MenuFlyoutItemBase[] children)
    {
        panel.Items.Clear();
        return panel.AddItems(children);
    }

    public static ElementType Items(this ElementType panel, IEnumerable<MenuFlyoutItemBase> children)
        => Items(panel, children.ToArray());

    public static ElementType AddItems(this ElementType panel, IEnumerable<MenuFlyoutItemBase> children)
        => AddItems(panel, children.ToArray());
    #endregion

    public static TElement MenuFlyoutPresenterStyle<TElement>(this TElement element, Style value) where TElement : ElementType
    { element.MenuFlyoutPresenterStyle = value; return element; }



}
