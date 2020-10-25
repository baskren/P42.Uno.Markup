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

        public static TElement Background<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Background = brush; return element; }

        public static TElement Background<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Background = new SolidColorBrush(color); return element; }

        public static TElement BackgroundTransition<TElement>(this TElement element, BrushTransition brushTransition) where TElement : ElementType
        { element.BackgroundTransition = brushTransition; return element; }
    }
}
