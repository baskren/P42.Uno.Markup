using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ElementType = Windows.UI.Xaml.Controls.NavigationView;

namespace P42.Uno.Markup
{
    public static class NavigationViewExtensions
    {
        public static TElement MenuItemTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.MenuItemTemplate = value; return element; }

        public static TElement MenuItemTemplate<TElement>(this TElement element, Type value) where TElement : ElementType
        { element.MenuItemTemplate = UIElementExtensions.AsDataTemplate(value); return element; }

        public static TElement MenuItemContainerStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.MenuItemContainerStyle = value; return element; }

        public static TElement SettingsVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSettingsVisible = value; return element; }

        public static TElement PaneToggleButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsPaneToggleButtonVisible = value; return element; }

        public static TElement PaneOpen<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsPaneOpen = value; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.HeaderTemplate = value; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, Type value) where TElement : ElementType
        { element.HeaderTemplate = UIElementExtensions.AsDataTemplate(value); return element; }

        public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Header = value; return element; }

        public static TElement ExpandedModeThresholdWidth<TElement>(this TElement element, double value) where TElement : ElementType
        { element.ExpandedModeThresholdWidth = value; return element; }

        public static TElement MenuItemsSource<TElement>(this TElement element, object value) where TElement : ElementType
        { element.MenuItemsSource = value; return element; }

        public static TElement CompactPaneLength<TElement>(this TElement element, double value) where TElement : ElementType
        { element.CompactPaneLength = value; return element; }

        public static TElement CompactModeThresholdWidth<TElement>(this TElement element, double value) where TElement : ElementType
        { element.CompactModeThresholdWidth = value; return element; }

        public static TElement AutoSuggestBox<TElement>(this TElement element, AutoSuggestBox value) where TElement : ElementType
        { element.AutoSuggestBox = value; return element; }

        public static TElement OpenPaneLength<TElement>(this TElement element, double value) where TElement : ElementType
        { element.OpenPaneLength = value; return element; }

        public static TElement AlwaysShowHeader<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.AlwaysShowHeader = value; return element; }

        public static TElement SelectedItem<TElement>(this TElement element, object value) where TElement : ElementType
        { element.SelectedItem = value; return element; }

        public static TElement PaneToggleButtonStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.PaneToggleButtonStyle = value; return element; }

        public static TElement PaneFooter<TElement>(this TElement element, UIElement value) where TElement : ElementType
        { element.PaneFooter = value; return element; }

        public static TElement PaneTitle<TElement>(this TElement element, string value) where TElement : ElementType
        { element.PaneTitle = value; return element; }

        public static TElement BackEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsBackEnabled = value; return element; }

        public static TElement BackButtonVisible<TElement>(this TElement element, NavigationViewBackButtonVisible value = NavigationViewBackButtonVisible.Visible) where TElement : ElementType
        { element.IsBackButtonVisible = value; return element; }

        public static TElement ShoulderNavigationEnabled<TElement>(this TElement element, NavigationViewShoulderNavigationEnabled value = NavigationViewShoulderNavigationEnabled.Always) where TElement : ElementType
        { element.ShoulderNavigationEnabled = value; return element; }

        public static TElement SelectionFollowsFocus<TElement>(this TElement element, NavigationViewSelectionFollowsFocus value = NavigationViewSelectionFollowsFocus.Enabled) where TElement : ElementType
        { element.SelectionFollowsFocus = value; return element; }

        public static TElement PaneHeader<TElement>(this TElement element, UIElement value) where TElement : ElementType
        { element.PaneHeader = value; return element; }

        public static TElement PaneDisplayMode<TElement>(this TElement element, NavigationViewPaneDisplayMode value) where TElement : ElementType
        { element.PaneDisplayMode = value; return element; }

        public static TElement PaneCustomContent<TElement>(this TElement element, UIElement value) where TElement : ElementType
        { element.PaneCustomContent = value; return element; }

        public static TElement OverflowLabelMode<TElement>(this TElement element, NavigationViewOverflowLabelMode value) where TElement : ElementType
        { element.OverflowLabelMode = value; return element; }

        public static TElement PaneVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsPaneVisible = value; return element; }

        public static TElement ContentOverlay<TElement>(this TElement element, UIElement value) where TElement : ElementType
        { element.ContentOverlay = value; return element; }

        public static TElement AddMenuItems<TElement>(this TElement element, params NavigationViewItem[] items) where TElement : ElementType
        {
            if (items != null)
            {
                foreach (var item in items)
                    element.MenuItems.Add(item);
            }
            return element;
        }

        public static TElement MenuItems<TElement>(this TElement element, params NavigationViewItem[] items) where TElement : ElementType
        {
            element.MenuItems.Clear();
            return element.AddMenuItems(items);
        }

        public static TElement AddOnDisplayModeChanged<TElement>(this TElement element, TypedEventHandler<NavigationView, NavigationViewDisplayModeChangedEventArgs> value) where TElement : ElementType
        { element.DisplayModeChanged += value; return element; }

        public static TElement AddOnItemInvoked<TElement>(this TElement element, TypedEventHandler<NavigationView, NavigationViewItemInvokedEventArgs> value) where TElement : ElementType
        { element.ItemInvoked += value; return element; }

        public static TElement AddOnSelectionChanged<TElement>(this TElement element, TypedEventHandler<NavigationView, NavigationViewSelectionChangedEventArgs> value) where TElement : ElementType
        { element.SelectionChanged += value; return element; }

        public static TElement AddOnBackRequested<TElement>(this TElement element, TypedEventHandler<NavigationView, NavigationViewBackRequestedEventArgs> value) where TElement : ElementType
        { element.BackRequested += value; return element; }

        public static TElement AddOnPaneClosed<TElement>(this TElement element, TypedEventHandler<NavigationView, object> value) where TElement : ElementType
        { element.PaneClosed += value; return element; }

        public static TElement AddOnPaneClosing<TElement>(this TElement element, TypedEventHandler<NavigationView, NavigationViewPaneClosingEventArgs> value) where TElement : ElementType
        { element.PaneClosing += value; return element; }

        public static TElement AddOnPaneOpened<TElement>(this TElement element, TypedEventHandler<NavigationView, object> value) where TElement : ElementType
        { element.PaneOpened += value; return element; }

        public static TElement AddOnPaneOpening<TElement>(this TElement element, TypedEventHandler<NavigationView, object> value) where TElement : ElementType
        { element.PaneOpening += value; return element; }


    }
}