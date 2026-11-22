using ElementType = Microsoft.UI.Xaml.Controls.CalendarViewDayItem;

namespace P42.Uno.Markup;

public static class CalendarViewDayItemExtensions
{
    public static TElement IsBlackout<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsBlackout = value; return element; }


}