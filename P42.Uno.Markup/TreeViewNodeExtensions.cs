using System.Collections.Generic;
using System.Linq;
using ElementType = Microsoft.UI.Xaml.Controls.TreeViewNode;
using Microsoft.UI.Xaml.Controls;


namespace P42.Uno.Markup
{
    public static class TreeViewNodeExtensions
    {
        #region Properties

        #region Children
        public static TElement AddChildren<TElement>(this TElement element, params TreeViewNode[] children) where TElement : ElementType
        {
            if (children != null)
            {
                foreach (var child in children)
                {
                    element.Children.Add(child);
                }
            }
            return element;
        }

        public static TElement Children<TElement>(this TElement element, params TreeViewNode[] children) where TElement : ElementType
        {
            element.Children.Clear();
            return element.AddChildren(children);
        }

        public static TElement Children<TElement>(this TElement element, IEnumerable<TreeViewNode> children) where TElement : ElementType
            => Children(element, children.ToArray());

        public static TElement AddChildren<TElement>(this TElement element, IEnumerable<TreeViewNode> children) where TElement : ElementType
            => AddChildren(element, children.ToArray());
        #endregion

        public static TElement Content<TElement>(this TElement element, object value) where TElement : ElementType
        {
            element.Content = value; return element;
        }

        public static TElement HasUnrealizedChildren<TElement>(this TElement element, bool value = true) where TElement : ElementType
        {
            element.HasUnrealizedChildren = value; return element;
        }

        public static TElement IsExpanded<TElement>(this TElement element, bool value = true) where TElement : ElementType
        {
            element.IsExpanded = value; return element;
        }
        #endregion


        #region Events
        #endregion
    }
}
