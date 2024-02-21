using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.RadioButtons;

namespace P42.Uno.Markup;
public static class RadioButtonsExtensions
{

    public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Header = value; return element; }


    public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.HeaderTemplate = value; return element; }


    public static TElement ItemsSource<TElement>(this TElement element, object value) where TElement : ElementType
    { element.ItemsSource = value; return element; }

    public static TElement ItemTemplate<TElement>(this TElement element, object value) where TElement : ElementType
    { element.ItemTemplate = value; return element; }

    public static TElement MaxColumns<TElement>(this TElement element, int value) where TElement : ElementType
    { element.MaxColumns = value; return element; }

    public static TElement SelectedIndex<TElement>(this TElement element, int value) where TElement : ElementType
    { element.SelectedIndex = value; return element; }

    public static TElement SelectedItem<TElement>(this TElement element, object value) where TElement : ElementType
    { element.SelectedItem = value; return element; }


    #region Events

    public static TElement AddSelectionChangedHandler<TElement>(this TElement element, SelectionChangedEventHandler handler) where TElement : ElementType
    { element.SelectionChanged += handler; return element; }
    #endregion
}
