using System.Xml.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.Pivot;

namespace P42.Uno.Markup;
public static class PivotExtensions
{


    
    #region Attached Properties
    public static TElement SlideInAnimationGroup<TElement>(this TElement element, PivotSlideInAnimationGroup value) where TElement : FrameworkElement
    { Pivot.SetSlideInAnimationGroup(element, value); return element; }
    #endregion

}
