using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.MenuFlyoutSubItem;

namespace P42.Uno.Markup;
public static class MenuFlyoutSubItemExtensions
{
    #region Icon
    public static ElementType Icon(this ElementType element, IconElement value = null) 
    { element.Icon = value; return element; }

    public static ElementType Icon(this ElementType element, Symbol value) 
    { element.Icon = new SymbolIcon { Symbol = value }; return element; }

    public static ElementType Icon(this ElementType element, string glyph, FontFamily fontFamily) 
    { element.Icon = new FontIcon { FontFamily = fontFamily, Glyph = glyph }; return element; }

    public static ElementType Icon(this ElementType element, string glyph, FontFamily fontFamily, double fontSize) 
    { element.Icon = new FontIcon { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

    public static ElementType Icon(this ElementType element, Geometry path) 
    { element.Icon = new PathIcon { Data = path }; return element; }

    public static ElementType Icon(this ElementType element, Uri bitMapUriSource, bool showAsMonoChrome = true) 
    { element.Icon = new BitmapIcon { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
    #endregion

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


    public static ElementType Text(this ElementType element, string value)
    { element.Text = value; return element; }

}
