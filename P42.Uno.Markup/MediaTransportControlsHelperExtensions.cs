using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;
public static class MediaTransportControlsHelperExtensions
{

    public static TElement DropoutOrder<TElement>(this TElement element, int? value) where TElement : UIElement
    { MediaTransportControlsHelper.SetDropoutOrder(element,value); return element; }
}
