using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.Panel;

namespace P42.Uno.Markup
{
    public static class PanelExtensions
    {
        public static TElement ChildrenTransitions<TElement>(this TElement element, TransitionCollection collection) where TElement : ElementType
        { element.ChildrenTransitions = collection; return element; }

        #region Background
        public static TElement Background<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Background = brush; return element; }

        public static TElement Background<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Background = new SolidColorBrush(color); return element; }

        public static TElement Background<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.Background = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromString(hex)); return element; }
        #endregion

        public static TElement BackgroundTransition<TElement>(this TElement element, BrushTransition brushTransition) where TElement : ElementType
        { element.BackgroundTransition = brushTransition; return element; }

        public static TElement Children<TElement>(this TElement panel, params UIElement[] children) where TElement : ElementType
        {
            panel.Children.Clear();
            foreach (var child in children)
            {
                panel.Children.Add(child);
            }
            return panel;
        }

        public static TElement Children<TElement>(this TElement panel, IEnumerable<UIElement> children) where TElement : ElementType
            => Children(panel, children.ToArray());

        public static TElement Children<TElement>(this TElement panel, IEnumerable<FrameworkElement> children) where TElement : ElementType
            => Children(panel, children.Cast<UIElement>().ToArray());
    }
}
