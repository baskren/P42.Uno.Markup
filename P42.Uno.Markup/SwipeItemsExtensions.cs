using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;
public static class SwipeItemsExtensions
{
    public static SwipeItems Mode(this SwipeItems swipeItems, SwipeMode mode)
    {  swipeItems.Mode = mode; return swipeItems; }


}
