﻿using P42.Utils.Uno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.ContentControl;

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

        public static TElement Content<TElement>(this TElement element, object content) where TElement : ElementType
        { element.Content = content; return element; }

        public static TElement BindNullCollapse<TElement>(this TElement element) where TElement : ElementType
        {
            return element.Bind(ContentPresenter.VisibilityProperty, element, nameof(Content),
                           convert: (object content) => (content != null).ToVisibility());
        }
    }
}
