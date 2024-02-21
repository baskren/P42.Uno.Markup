using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.RatingControl;

namespace P42.Uno.Markup;
public static class RatingControlExtensions
{
    public static TElement Caption<TElement>(this TElement element, string caption) where TElement : ElementType
    { element.Caption = caption ?? string.Empty; return element; }

    public static TElement InitialSetValue<TElement>(this TElement element, int value) where TElement : ElementType
    { element.InitialSetValue = value; return element; }

    public static TElement IsClearEnabled<TElement>(this TElement element, bool value  = true) where TElement : ElementType
    { element.IsClearEnabled = value; return element; }

    public static TElement IsReadOnly<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsReadOnly = value; return element; }

    public static TElement RatingItemInfo<TElement>(this TElement element, RatingItemInfo value) where TElement : ElementType
    { element.ItemInfo = value; return element; }

    public static TElement MaxRating<TElement>(this TElement element, int value) where TElement : ElementType
    { element.MaxRating = value; return element; }

    public static TElement PlaceholderValue<TElement>(this TElement element, double value) where TElement : ElementType
    { element.PlaceholderValue = value; return element; }

    public static TElement Value<TElement>(this TElement element, double value) where TElement : ElementType
    { element.Value = value; return element; }


    #region Events
    public static TElement AddValueChangedHandler<TElement>(this TElement element, TypedEventHandler<RatingControl, object> handler) where TElement : ElementType
    { element.ValueChanged += handler; return element; }
    #endregion
}
