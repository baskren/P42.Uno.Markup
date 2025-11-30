using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using ElementType = Microsoft.UI.Xaml.Controls.Panel;

namespace P42.Uno.WinUI.Markup;

public static class PanelExtensions
{
    
    public static TElement AddChildren<TElement>(this TElement panel, params IEnumerable<UIElement> children) where TElement : ElementType
    {
        if (children != null)
        {
            foreach (var child in children)
            {
                panel.Children.Add(child);
            }
        }
        return panel;
    }
    

    public static TElement Children<TElement>(this TElement panel, params IEnumerable<UIElement> children) where TElement : ElementType
    {
        panel.Children.Clear();
        return panel.AddChildren(children);
    }

    /*
    public static TElement Children<TElement>(this TElement panel, IEnumerable<FrameworkElement> children) where TElement : ElementType
        => Children(panel, children);

    public static TElement AddChildren<TElement>(this TElement panel, IEnumerable<UIElement> children) where TElement : ElementType
        => AddChildren(panel, children.ToArray());

    public static TElement AddChildren<TElement>(this TElement panel, IEnumerable<FrameworkElement> children) where TElement : ElementType
        => AddChildren(panel, children.Cast<UIElement>().ToArray());
    */
}
