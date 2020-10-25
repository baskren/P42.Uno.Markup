using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.ComboBox;

namespace P42.Uno.Markup
{
    public static class ComboBoxExtensions
    {
        public static TElement MaxDropDownHeight<TElement>(this TElement element, double value) where TElement : ElementType
        { element.MaxDropDownHeight = value; return element; }

        public static TElement PlaceholderText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.PlaceholderText = value; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.HeaderTemplate = value; return element; }

        public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Header = value; return element; }

        public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
        { element.LightDismissOverlayMode = value; return element; }

        public static TElement IsTextSearchEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTextSearchEnabled = value; return element; }

        public static TElement SelectionChangedTrigger<TElement>(this TElement element, ComboBoxSelectionChangedTrigger value) where TElement : ElementType
        { element.SelectionChangedTrigger = value; return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.PlaceholderForeground = value; return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.PlaceholderForeground = new SolidColorBrush(value); return element; }

        public static TElement TextBoxStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.TextBoxStyle = value; return element; }

        public static TElement Text<TElement>(this TElement element, string value) where TElement : ElementType
        { element.Text = value; return element; }

        public static TElement Description<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Description = value; return element; }

    }
}
