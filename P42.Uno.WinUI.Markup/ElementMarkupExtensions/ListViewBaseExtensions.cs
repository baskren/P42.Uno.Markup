using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
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



}
