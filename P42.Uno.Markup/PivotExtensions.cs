using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.Pivot;

namespace P42.Uno.Markup;
public static class PivotExtensions
{

    public static TElement HeaderFocusVisualPlacement<TElement>(this TElement element, PivotHeaderFocusVisualPlacement value) where TElement : ElementType
    { element.HeaderFocusVisualPlacement = value; return element; }

    public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.HeaderTemplate = value; return element; }

    public static TElement IsHeaderItemsCarouselEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsHeaderItemsCarouselEnabled = value; return element; }

    public static TElement IsLocked<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsLocked = value; return element; }

    public static TElement LeftHeader<TElement>(this TElement element, object value) where TElement : ElementType
    { element.LeftHeader = value; return element; }

    public static TElement LeftHeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.LeftHeaderTemplate = value; return element; }

    public static TElement RightHeader<TElement>(this TElement element, object value) where TElement : ElementType
    { element.RightHeader = value; return element; }

    public static TElement RightHeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.RightHeaderTemplate = value; return element; }

    public static TElement SelectedIndex<TElement>(this TElement element, int value) where TElement : ElementType
    { element.SelectedIndex = value; return element; }

    public static TElement SelectedItem<TElement>(this TElement element, object value) where TElement : ElementType
    { element.SelectedItem = value; return element; }

    public static TElement Title<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Title = value; return element; }

    public static TElement TitleTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.TitleTemplate = value; return element; }


    #region Events
    public static TElement AddPivotItemLoadedHandler<TElement>(this TElement element, TypedEventHandler<Pivot, PivotItemEventArgs> handler) where TElement : ElementType
    { element.PivotItemLoaded += handler; return element; }

    public static TElement AddPivotItemLoadingHandler<TElement>(this TElement element, TypedEventHandler<Pivot, PivotItemEventArgs> handler) where TElement : ElementType
    { element.PivotItemLoading += handler; return element; }

    public static TElement AddPivotItemUnloadedHandler<TElement>(this TElement element, TypedEventHandler<Pivot, PivotItemEventArgs> handler) where TElement : ElementType
    { element.PivotItemUnloaded += handler; return element; }

    public static TElement AddPivotItemUnloadingHandler<TElement>(this TElement element, TypedEventHandler<Pivot, PivotItemEventArgs> handler) where TElement : ElementType
    { element.PivotItemUnloading += handler; return element; }

    public static TElement AddSelectionChangedHandler<TElement>(this TElement element, SelectionChangedEventHandler handler) where TElement : ElementType
    { element.SelectionChanged += handler; return element; }
    #endregion


    #region Attached Properties
    public static TElement SlideInAnimationGroup<TElement>(this TElement element, PivotSlideInAnimationGroup value) where TElement : FrameworkElement
    { Pivot.SetSlideInAnimationGroup(element, value); return element; }
    #endregion

}
