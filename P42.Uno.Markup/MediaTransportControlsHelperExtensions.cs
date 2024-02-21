using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.MediaTransportControlsHelper;

namespace P42.Uno.Markup;
public static class MediaTransportControlsHelperExtensions
{

    public static TElement DropoutOrder<TElement>(this TElement element, int? value) where TElement : UIElement
    { MediaTransportControlsHelper.SetDropoutOrder(element,value); return element; }
}
