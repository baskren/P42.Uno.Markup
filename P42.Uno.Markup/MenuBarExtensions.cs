using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.MenuBar;

namespace P42.Uno.Markup;
public static class MenuBarExtensions
{
    #region Items
    public static ElementType AddItems(this ElementType panel, params MenuBarItem[] children)
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

    public static ElementType Items(this ElementType panel, params MenuBarItem[] children)
    {
        panel.Items.Clear();
        return panel.AddItems(children);
    }

    public static ElementType Items(this ElementType panel, IEnumerable<MenuBarItem> children)
        => Items(panel, children.ToArray());

    public static ElementType AddItems(this ElementType panel, IEnumerable<MenuBarItem> children)
        => AddItems(panel, children.ToArray());
    #endregion


}
