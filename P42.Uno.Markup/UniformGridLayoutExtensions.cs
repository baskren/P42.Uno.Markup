using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.UniformGridLayout;

namespace P42.Uno.Markup;
public static class UniformGridLayoutExtensions
{

    public static TElement ItemsJustification<TElement>(this TElement element, UniformGridLayoutItemsJustification value) where TElement : ElementType
    { element.ItemsJustification = value; return element; }


    public static TElement ItemsStretch<TElement>(this TElement element, UniformGridLayoutItemsStretch value) where TElement : ElementType
    { element.ItemsStretch = value; return element; }


    public static TElement MaximumRowsOrColumns<TElement>(this TElement element, int value) where TElement : ElementType
    { element.MaximumRowsOrColumns = value; return element; }


    public static TElement MinColumnSpacing<TElement>(this TElement element, double value) where TElement : ElementType
    { element.MinColumnSpacing = value; return element; }


    public static TElement MinItemHeight<TElement>(this TElement element, double value) where TElement : ElementType
    { element.MinItemHeight = value; return element; }


    public static TElement MinItemWidth<TElement>(this TElement element, double value) where TElement : ElementType
    { element.MinItemWidth = value; return element; }


    public static TElement MinRowSpacing<TElement>(this TElement element, double value) where TElement : ElementType
    { element.MinRowSpacing = value; return element; }


    public static TElement Orientation<TElement>(this TElement element, Orientation value) where TElement : ElementType
    { element.Orientation = value; return element; }


}
