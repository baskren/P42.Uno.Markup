using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.SwipeControl;

namespace P42.Uno.Markup
{
    public static class SwipeControlExtensions
    {
        static SwipeItems AsSwipeItems(this SwipeItem[] items, SwipeMode mode = default)
        {
            var swipeItems = new SwipeItems
            {
                Mode = mode
            };
            foreach (var item in items)
                swipeItems.Add(item);
            return swipeItems;
        }
        public static TElement BottomItems<TElement>(this TElement element, SwipeItems items) where TElement : ElementType
        {
            element.BottomItems = items;
            return element;
        }

        public static TElement BottomItems<TElement>(this TElement element, params SwipeItem[] items) where TElement : ElementType
            => BottomItems(element, items.AsSwipeItems());

        public static TElement BottomItems<TElement>(this TElement element, SwipeMode mode, params SwipeItem[] items) where TElement : ElementType
            => BottomItems(element, items.AsSwipeItems(mode));

        public static TElement RightItems<TElement>(this TElement element, SwipeItems items) where TElement : ElementType
        {
            element.RightItems = items;
            return element;
        }

        public static TElement RightItems<TElement>(this TElement element, SwipeMode mode, params SwipeItem[] items) where TElement : ElementType
            => RightItems(element, items.AsSwipeItems(mode));

        public static TElement RightItems<TElement>(this TElement element, params SwipeItem[] items) where TElement : ElementType
            => RightItems(element, items.AsSwipeItems());

        public static TElement TopItems<TElement>(this TElement element, SwipeItems items) where TElement : ElementType
        {
            element.TopItems = items;
            return element;
        }

        public static TElement TopItems<TElement>(this TElement element, params SwipeItem[] items) where TElement : ElementType
            => TopItems(element, items.AsSwipeItems());

        public static TElement TopItems<TElement>(this TElement element, SwipeMode mode, params SwipeItem[] items) where TElement : ElementType
            => TopItems(element, items.AsSwipeItems(mode));

    }
}