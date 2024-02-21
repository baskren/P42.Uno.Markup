using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ElementType = Microsoft.UI.Xaml.Controls.TabView;

namespace P42.Uno.Markup;
public static class TabViewExtensions
{
    public static TElement AddTabButtonCommand<TElement>(this TElement element, ICommand value) where TElement : ElementType
    { element.AddTabButtonCommand = value; return element; }

    public static TElement AddTabButtonCommandParameter<TElement>(this TElement element, object item) where TElement : ElementType
    { element.AddTabButtonCommandParameter = item; return element; }

    public static TElement AllowDropTabs<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.AllowDropTabs = value; return element; }

    public static TElement CanDragTabs<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.CanDragTabs = value; return element; }

    public static TElement CanReorderTabs<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.CanReorderTabs = value; return element; }

    public static TElement CloseButtonOverlayMode<TElement>(this TElement element, TabViewCloseButtonOverlayMode value) where TElement : ElementType
    { element.CloseButtonOverlayMode = value; return element; }

    public static TElement IsAddTabButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsAddTabButtonVisible = value; return element; }

    public static TElement SelectedIndex<TElement>(this TElement element, int value) where TElement : ElementType
    { element.SelectedIndex = value; return element; }

    public static TElement SelectedItem<TElement>(this TElement element, object item) where TElement : ElementType
    { element.SelectedItem = item; return element; }

    #region Items
    public static TElement AddTabItems<TElement>(this TElement element, params object[] children) where TElement : ElementType
    {
        if (children != null)
        {
            foreach (var child in children)
            {
                element.TabItems.Add(child);
            }
        }
        return element;
    }

    public static TElement TabItems<TElement>(this TElement element, params object[] children) where TElement : ElementType
    {
        element.TabItems.Clear();
        return element.AddTabItems(children);
    }

    public static TElement TabItems<TElement>(this TElement element, IEnumerable<object> children) where TElement : ElementType
        => TabItems(element, children.ToArray());

    public static TElement AddTabItems<TElement>(this TElement element, IEnumerable<object> children) where TElement : ElementType
        => AddTabItems(element, children.ToArray());

    #endregion

    public static TElement TabItemsSource<TElement>(this TElement element, object items) where TElement : ElementType
    { element.TabItemsSource = items; return element; }

    public static TElement TabItemTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.TabItemTemplate = value; return element; }

    public static TElement TabItemTemplateSelector<TElement>(this TElement element, DataTemplateSelector value) where TElement : ElementType
    { element.TabItemTemplateSelector = value; return element; }

    public static TElement TabStripFooter<TElement>(this TElement element, object item) where TElement : ElementType
    { element.TabStripFooter = item; return element; }

    public static TElement TabStripFooterTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.TabStripFooterTemplate = value; return element; }

    public static TElement TabStripHeader<TElement>(this TElement element, object item) where TElement : ElementType
    { element.TabStripHeader = item; return element; }

    public static TElement TabStripHeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.TabStripHeaderTemplate = value; return element; }

    public static TElement TabWidthMode<TElement>(this TElement element, TabViewWidthMode value) where TElement : ElementType
    { element.TabWidthMode = value; return element; }

    #region Events
    public static TElement AddAddTabButtonClickHandler<TElement>(this TElement element, TypedEventHandler<TabView, object> handler) where TElement : ElementType
    { element.AddTabButtonClick += handler; return element; }

    public static TElement AddSelectionChangedHandler<TElement>(this TElement element, SelectionChangedEventHandler handler) where TElement : ElementType
    { element.SelectionChanged += handler; return element; }

    public static TElement AddTabCloseRequestedHandler<TElement>(this TElement element, TypedEventHandler<TabView, TabViewTabCloseRequestedEventArgs> handler) where TElement : ElementType
    { element.TabCloseRequested += handler; return element; }

    public static TElement AddTabDragCompletedHandler<TElement>(this TElement element, TypedEventHandler<TabView, TabViewTabDragCompletedEventArgs> handler) where TElement : ElementType
    { element.TabDragCompleted += handler; return element; }

    public static TElement AddTabDragStartingHandler<TElement>(this TElement element, TypedEventHandler<TabView, TabViewTabDragStartingEventArgs> handler) where TElement : ElementType
    { element.TabDragStarting += handler; return element; }

    public static TElement TabDroppedOutside<TElement>(this TElement element, TypedEventHandler<TabView, TabViewTabDroppedOutsideEventArgs> handler) where TElement : ElementType
    { element.TabDroppedOutside += handler; return element; }

    public static TElement AddTabItemsChangedHandler<TElement>(this TElement element, TypedEventHandler<TabView, IVectorChangedEventArgs> handler) where TElement : ElementType
    { element.TabItemsChanged += handler; return element; }

    public static TElement AddTabStripDragOverHandler<TElement>(this TElement element, DragEventHandler handler) where TElement : ElementType
    { element.TabStripDragOver += handler; return element; }

    public static TElement AddTabStripDropHandler<TElement>(this TElement element, DragEventHandler handler) where TElement : ElementType
    { element.TabStripDrop += handler; return element; }

    #endregion

}
