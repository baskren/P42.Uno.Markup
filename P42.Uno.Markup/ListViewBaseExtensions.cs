using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.ListViewBase;

namespace P42.Uno.Markup;

public static class ListViewBaseExtensions
{
    public static readonly Style SimpleItemContainerStyle = new()
    {
        TargetType = typeof(ListViewItem),
        Setters = {
            new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch),
            new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Stretch),
            new Setter(FrameworkElement.MarginProperty, new Thickness(0)),
            new Setter(Control.PaddingProperty, new Thickness(0)),
        }
    };

    public static TElement UseSimpleItemContainerStyle<TElement>(this TElement element, bool value = true) where TElement : ElementType
    {
        element.ItemContainerStyle = value ? SimpleItemContainerStyle : null;
        return element;
    }

    #region Properties
    public static TElement CanDragItems<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.CanDragItems = value; return element; }

    public static TElement CanReorderItems<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.CanReorderItems = value; return element; }

    public static TElement DataFetchSize<TElement>(this TElement element, double value) where TElement : ElementType
    { element.DataFetchSize = value; return element; }

    public static TElement Footer<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Footer = value; return element; }

    public static TElement FooterTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.FooterTemplate = value; return element; }

    public static TElement FooterTemplate<TElement>(this TElement element, Type type) where TElement : ElementType
    { element.FooterTemplate = type.AsDataTemplate(); return element; }

    public static TElement FooterTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
    { element.FooterTransitions = value; return element; }

    public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Header = value; return element; }

    public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.HeaderTemplate = value; return element; }

    public static TElement HeaderTemplate<TElement>(this TElement element, Type type) where TElement : ElementType
    { element.HeaderTemplate = type.AsDataTemplate(); return element; }

    public static TElement HeaderTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
    { element.HeaderTransitions = value; return element; }

    public static TElement IncrementalLoadingThreshold<TElement>(this TElement element, double value) where TElement : ElementType
    { element.IncrementalLoadingThreshold = value; return element; }

    public static TElement IncrementalLoadingTrigger<TElement>(this TElement element, IncrementalLoadingTrigger value) where TElement : ElementType
    { element.IncrementalLoadingTrigger = value; return element; }

    public static TElement ActiveView<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsActiveView = value; return element; }

    public static TElement ItemClickEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsItemClickEnabled = value; return element; }

    public static TElement MultiSelectCheckBoxEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsMultiSelectCheckBoxEnabled = value; return element; }

    public static TElement SwipeEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSwipeEnabled = value; return element; }

    public static TElement ZoomedInView<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsZoomedInView = value; return element; }

    public static TElement ReorderMode<TElement>(this TElement element, ListViewReorderMode value) where TElement : ElementType
    { element.ReorderMode = value; return element; }

    public static TElement SelectionMode<TElement>(this TElement element, ListViewSelectionMode value) where TElement : ElementType
    { element.SelectionMode = value; return element; }

    public static TElement SemanticZoomOwner<TElement>(this TElement element, SemanticZoom value) where TElement : ElementType
    { element.SemanticZoomOwner = value; return element; }

    public static TElement ShowsScrollingPlaceholders<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.ShowsScrollingPlaceholders = value; return element; }

    public static TElement SingleSelectionFollowsFocus<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.SingleSelectionFollowsFocus = value; return element; }
    #endregion


    #region Events
    public static TElement AddChoosingGroupHeaderContainerHandler<TElement>(this TElement element, TypedEventHandler<ListViewBase, ChoosingGroupHeaderContainerEventArgs> handler) where TElement : ElementType
    { element.ChoosingGroupHeaderContainer += handler; return element; }

    public static TElement AddChoosingItemContainerHandler<TElement>(this TElement element, TypedEventHandler<ListViewBase, ChoosingItemContainerEventArgs> handler) where TElement : ElementType
    { element.ChoosingItemContainer += handler; return element; }

    public static TElement AddContainerContentChangingHandler<TElement>(this TElement element, TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> handler) where TElement : ElementType
    { element.ContainerContentChanging += handler; return element; }

    public static TElement AddDragItemsCompletedHandler<TElement>(this TElement element, TypedEventHandler<ListViewBase, DragItemsCompletedEventArgs> handler) where TElement : ElementType
    { element.DragItemsCompleted += handler; return element; }

    public static TElement AddDragItemsStartingHandler<TElement>(this TElement element, DragItemsStartingEventHandler handler) where TElement : ElementType
    { element.DragItemsStarting += handler; return element; }

    public static TElement AddItemClickHandler<TElement>(this TElement element, ItemClickEventHandler handler) where TElement : ElementType
    { element.ItemClick += handler; element.IsItemClickEnabled=true; return element; }
    #endregion


}
