using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.ParallaxView;

namespace P42.Uno.Markup;
public static class ParallaxViewExtensions
{

    public static TElement Child<TElement>(this TElement element, UIElement value) where TElement : ElementType
    { element.Child = value; return element; }

    public static TElement HorizontalShift<TElement>(this TElement element, double value) where TElement : ElementType
    { element.HorizontalShift = value; return element; }

    public static TElement HorizontalSourceEndOffset<TElement>(this TElement element, double value) where TElement : ElementType
    { element.HorizontalSourceEndOffset = value; return element; }

    public static TElement HorizontalSourceOffsetKind<TElement>(this TElement element, ParallaxSourceOffsetKind value) where TElement : ElementType
    { element.HorizontalSourceOffsetKind = value; return element; }

    public static TElement HorizontalSourceStartOffset<TElement>(this TElement element, double value) where TElement : ElementType
    { element.HorizontalSourceStartOffset = value; return element; }

    public static TElement IsHorizontalShiftClamped<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsHorizontalShiftClamped = value; return element; }

    public static TElement IsVerticalShiftClamped<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsVerticalShiftClamped = value; return element; }

    public static TElement MaxHorizontalShiftRatio<TElement>(this TElement element, double value) where TElement : ElementType
    { element.MaxHorizontalShiftRatio = value; return element; }

    public static TElement MaxVerticalShiftRatio<TElement>(this TElement element, double value) where TElement : ElementType
    { element.MaxVerticalShiftRatio = value; return element; }

    public static TElement Source<TElement>(this TElement element, UIElement value) where TElement : ElementType
    { element.Source = value; return element; }

    public static TElement VerticalShift<TElement>(this TElement element, double value) where TElement : ElementType
    { element.VerticalShift = value; return element; }

    public static TElement VerticalSourceEndOffset<TElement>(this TElement element, double value) where TElement : ElementType
    { element.VerticalSourceEndOffset = value; return element; }

    public static TElement VerticalSourceOffsetKind<TElement>(this TElement element, ParallaxSourceOffsetKind value) where TElement : ElementType
    { element.VerticalSourceOffsetKind = value; return element; }

    public static TElement VerticalSourceStartOffset<TElement>(this TElement element, double value) where TElement : ElementType
    { element.VerticalSourceStartOffset = value; return element; }
}
