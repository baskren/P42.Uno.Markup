using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using ElementType = Microsoft.UI.Xaml.Controls.ContentControl;

namespace P42.Uno.Markup
{
    public static class ContentControlExtensions
    {
        public static TElement ContentTransitions<TElement>(this TElement element, TransitionCollection collection) where TElement : ElementType
        { element.ContentTransitions = collection; return element; }

        public static TElement ContentTemplateSelector<TElement>(this TElement element, DataTemplateSelector selector) where TElement : ElementType
        { element.ContentTemplateSelector = selector; return element; }

        public static TElement ContentTemplate<TElement>(this TElement element, DataTemplate selector) where TElement : ElementType
        { element.ContentTemplate = selector; return element; }

        public static TElement ContentTemplate<TElement>(this TElement element, Type type) where TElement : ElementType
        { element.ContentTemplate = type.AsDataTemplate(); return element; }

        public static TElement Content<TElement>(this TElement element, object content = null) where TElement : ElementType
        { element.Content = content; return element; }

        public static TElement BindNullCollapse<TElement>(this TElement element) where TElement : ElementType
        {
            return element.Bind(ContentPresenter.VisibilityProperty, element, nameof(Content),
                           convert: (object content) => content != null ? Visibility.Visible : Visibility.Collapsed);
        }
    }
}
