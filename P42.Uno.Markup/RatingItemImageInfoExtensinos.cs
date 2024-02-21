using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.RatingItemImageInfo;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup;
public static class RatingItemImageInfoExtensions
{
    public static TElement DisabledImage<TElement>(this  TElement element, ImageSource source) where TElement : ElementType
    { element.DisabledImage = source; return element; }

    public static TElement Image<TElement>(this TElement element, ImageSource source) where TElement : ElementType
    { element.Image = source; return element; }

    public static TElement PointerOverImage<TElement>(this TElement element, ImageSource source) where TElement : ElementType
    { element.PointerOverImage = source; return element; }

    public static TElement PlaceholderImage<TElement>(this TElement element, ImageSource source) where TElement : ElementType
    { element.PlaceholderImage = source; return element; }

    public static TElement PointerOverPlaceholderImage<TElement>(this TElement element, ImageSource source) where TElement : ElementType
    { element.PointerOverPlaceholderImage = source; return element; }

    public static TElement UnsetImage<TElement>(this TElement element, ImageSource source) where TElement : ElementType
    { element.UnsetImage = source; return element; }
}
