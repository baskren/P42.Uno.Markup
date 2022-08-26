using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Animation;
using ElementType = Microsoft.UI.Xaml.Controls.ListViewBase;

namespace P42.Uno.Markup
{
    public static class ListViewBaseExtensions
    {
        public static TElement SelectionMode<TElement>(this TElement element, ListViewSelectionMode value) where TElement : ElementType
        { element.SelectionMode = value; return element; }

        public static TElement SwipeEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSwipeEnabled = value; return element; }

        public static TElement ItemClickEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsItemClickEnabled = value; return element; }

        public static TElement IncrementalLoadingTrigger<TElement>(this TElement element, IncrementalLoadingTrigger value) where TElement : ElementType
        { element.IncrementalLoadingTrigger = value; return element; }

        public static TElement IncrementalLoadingThreshold<TElement>(this TElement element, double value) where TElement : ElementType
        { element.IncrementalLoadingThreshold = value; return element; }

        public static TElement HeaderTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
        { element.HeaderTransitions = value; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.HeaderTemplate = value; return element; }

        public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Header = value; return element; }

        public static TElement DataFetchSize<TElement>(this TElement element, double value) where TElement : ElementType
        { element.DataFetchSize = value; return element; }

        public static TElement CanReorderItems<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.CanReorderItems = value; return element; }

        public static TElement CanDragItems<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.CanDragItems = value; return element; }

        public static TElement ShowsScrollingPlaceholders<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.ShowsScrollingPlaceholders = value; return element; }

        public static TElement FooterTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
        { element.FooterTransitions = value; return element; }

        public static TElement FooterTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.FooterTemplate = value; return element; }

        public static TElement Footer<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Footer = value; return element; }

        public static TElement ReorderMode<TElement>(this TElement element, ListViewReorderMode value) where TElement : ElementType
        { element.ReorderMode = value; return element; }

        public static TElement MultiSelectCheckBoxEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsMultiSelectCheckBoxEnabled = value; return element; }

        public static TElement SingleSelectionFollowsFocus<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.SingleSelectionFollowsFocus = value; return element; }

        public static TElement SemanticZoomOwner<TElement>(this TElement element, SemanticZoom value) where TElement : ElementType
        { element.SemanticZoomOwner = value; return element; }

        public static TElement ZoomedInView<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsZoomedInView = value; return element; }

        public static TElement ActiveView<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsActiveView = value; return element; }


    }
}
