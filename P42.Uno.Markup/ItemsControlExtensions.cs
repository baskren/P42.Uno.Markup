﻿    using System;
    using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media.Animation;
using ElementType = Microsoft.UI.Xaml.Controls.ItemsControl;

namespace P42.Uno.Markup
{
    public static class ItemsControlExtensions
    {

        public static TElement ItemContainerStyle<TElement>(this TElement element, Style style) where TElement : ElementType
        { element.ItemContainerStyle = style; return element; }

        public static TElement ItemsSource<TElement>(this TElement element, object source) where TElement : ElementType
        { element.ItemsSource = source; return element; }

        public static TElement ItemsPanel<TElement>(this TElement element, ItemsPanelTemplate panelTemplate) where TElement : ElementType
        { element.ItemsPanel = panelTemplate; return element; }

        public static TElement ItemTemplateSelector<TElement>(this TElement element, DataTemplateSelector templateSelector) where TElement : ElementType
        { element.ItemTemplateSelector = templateSelector; return element; }

        public static TElement ItemTemplate<TElement>(this TElement element, DataTemplate template) where TElement : ElementType
        { element.ItemTemplate = template; return element; }

        public static TElement ItemTemplate<TElement>(this TElement element, Type templateType) where TElement : ElementType
        {
#if HAS_UNO
            var template = new DataTemplate(() => (UIElement)Activator.CreateInstance(templateType));
#else
            var template = UIElementExtensions.AsDataTemplate(templateType);
#endif
            element.ItemTemplate = template; 
            return element; 
        }

        public static TElement ItemTemplate<TElement>(this TElement element, string xaml) where TElement : ElementType
        { element.ItemTemplate = (DataTemplate)XamlReader.Load(xaml); ; return element; }

        public static TElement ItemContainerTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
        { element.ItemContainerTransitions = value; return element; }

        public static TElement ItemContainerStyleSelector<TElement>(this TElement element, StyleSelector value) where TElement : ElementType
        { element.ItemContainerStyleSelector = value; return element; }

        public static TElement GroupStyleSelector<TElement>(this TElement element, GroupStyleSelector value) where TElement : ElementType
        { element.GroupStyleSelector = value; return element; }

        public static TElement DisplayMemberPath<TElement>(this TElement element, string value) where TElement : ElementType
        { element.DisplayMemberPath = value; return element; }

    }
}
