using ElementType = Microsoft.UI.Xaml.Controls.Panel;

namespace P42.Uno.WinUI.Markup;

public static class PanelExtensions
{
    
    extension<TElement>(TElement panel) where TElement : ElementType
    {
        public TElement AddChildren(params IEnumerable<UIElement> children)
        {
            foreach (var child in children)
                panel.Children.Add(child);

            return panel;
        }

        public TElement Children(params IEnumerable<UIElement> children)
        {
            panel.Children.Clear();
            return panel.AddChildren(children);
        }

        public TElement Children(IEnumerable<FrameworkElement> children) => panel.Children(children);
        public TElement AddChildren(IEnumerable<FrameworkElement> children) => panel.AddChildren(children.Cast<UIElement>().ToArray());
    }
}
