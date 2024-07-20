//NavigationViewItem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.NavigationViewItem;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup
{
    public static class NavigationViewItemExtensions
    {
        public static TElement HasUnrealizedChildren<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.HasUnrealizedChildren = value; return element; }

        #region Icon
        public static TElement Icon<TElement>(this TElement element, IconElement value = null) where TElement : ElementType
        { element.Icon = value; return element; }

        public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
        { element.Icon = new SymbolIcon { Symbol = value }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
        { element.Icon = new FontIcon { FontFamily = fontFamily, Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily) where TElement : ElementType
        { element.Icon = new FontIcon { FontFamily = new FontFamily(fontFamily), Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
        { element.Icon = new FontIcon { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily, double fontSize) where TElement : ElementType
        { element.Icon = new FontIcon { FontFamily = new FontFamily(fontFamily), FontSize = fontSize, Glyph = glyph }; return element; }

        public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
        { element.Icon = new PathIcon { Data = path }; return element; }

        public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
        { element.Icon = new BitmapIcon { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
        #endregion

        public static TElement IsExpanded<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsExpanded = value; return element; }

        #region MenuItems
        public static ElementType AddMenuItems(this ElementType panel, params object[] children)
        {
            if (children != null)
            {
                foreach (var child in children)
                {
                    panel.MenuItems.Add(child);
                }
            }
            return panel;
        }

        public static ElementType MenuItems(this ElementType panel, params object[] children)
        {
            panel.MenuItems.Clear();
            return panel.AddMenuItems(children);
        }

        public static ElementType MenuItems(this ElementType panel, IEnumerable<object> children)
            => MenuItems(panel, children.ToArray());

        public static ElementType AddMenuItems(this ElementType panel, IEnumerable<object> children)
            => AddMenuItems(panel, children.ToArray());
        #endregion

        public static TElement MenuItemsSource<TElement>(this TElement element, object value) where TElement : ElementType
        { element.MenuItemsSource = value; return element; }

        public static TElement SelectsOnInvoked<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.SelectsOnInvoked = value; return element; }

    }
}
