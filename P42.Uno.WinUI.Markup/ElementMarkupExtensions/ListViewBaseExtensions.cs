using ElementType = Microsoft.UI.Xaml.Controls.ListViewBase;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ListViewBaseExtensions
{
    /// <summary>
    /// Simpler list view item contains style
    /// </summary>
    public static readonly Style SimpleItemContainerStyle = new()
    {
        TargetType = typeof(ListViewItem),
        Setters = {
            new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch),
            new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Stretch),
            new Setter(FrameworkElement.MarginProperty, new Thickness(0)),
            new Setter(Control.PaddingProperty, new Thickness(0))
        }
    };

    /// <summary>
    /// Fluent setter for SimpleItemContainerStyle
    /// </summary>
    /// <param name="element"></param>
    /// <param name="value"></param>
    /// <typeparam name="TElement"></typeparam>
    /// <returns></returns>
    public static TElement UseSimpleItemContainerStyle<TElement>(this TElement element, bool value = true) where TElement : ElementType
    {
        element.ItemContainerStyle = value ? SimpleItemContainerStyle : null;
        return element;
    }



}
