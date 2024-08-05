using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.PipsPager;

namespace P42.Uno.Markup;
public static class PipsPagerExtensions
{

    public static TElement MaxVisiblePips<TElement>(this TElement element, int value) where TElement : ElementType
    { element.MaxVisiblePips = value; return element; }

    public static TElement NextButtonStyle<TElement>(this TElement element, Style value) where TElement : ElementType
    { element.NextButtonStyle = value; return element; }

    public static TElement NextButtonVisibility<TElement>(this TElement element, PipsPagerButtonVisibility value) where TElement : ElementType
    { element.NextButtonVisibility = value; return element; }

    public static TElement NormalPipStyle<TElement>(this TElement element, Style value) where TElement : ElementType
    { element.NormalPipStyle = value; return element; }

    public static TElement NumberOfPages<TElement>(this TElement element, int value) where TElement : ElementType
    { element.NumberOfPages = value; return element; }

    public static TElement Orientation<TElement>(this TElement element, Orientation value) where TElement : ElementType
    { element.Orientation = value; return element; }

    public static TElement PreviousButtonStyle<TElement>(this TElement element, Style value) where TElement : ElementType
    { element.PreviousButtonStyle = value; return element; }

    public static TElement PreviousButtonVisibility<TElement>(this TElement element, PipsPagerButtonVisibility value) where TElement : ElementType
    { element.PreviousButtonVisibility = value; return element; }

    public static TElement SelectedPageIndex<TElement>(this TElement element, int value) where TElement : ElementType
    { element.SelectedPageIndex = value; return element; }

    public static TElement SelectedPipStyle<TElement>(this TElement element, Style value) where TElement : ElementType
    { element.SelectedPipStyle = value; return element; }

    #region Events

    public static TElement AddSelectedIndexChangedHandler<TElement>(this TElement element, TypedEventHandler<PipsPager, PipsPagerSelectedIndexChangedEventArgs> handler) where TElement : ElementType
    { element.SelectedIndexChanged += handler; return element; }
    #endregion

}
