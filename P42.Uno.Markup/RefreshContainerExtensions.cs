using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.RefreshContainer;

namespace P42.Uno.Markup;

public static class RefreshContainerExtensions
{
    #region Properties
    public static TElement PullDirection<TElement>(this TElement element, RefreshPullDirection direction) where TElement : ElementType
    { element.PullDirection = direction; return element; }

    public static TElement Visualizer<TElement>(this TElement element, RefreshVisualizer visualizer) where TElement : ElementType
    { element.Visualizer = visualizer; return element; }
    #endregion


    #region Events
    public static TElement AddRefreshRequestedHandler<TElement>(this TElement element, TypedEventHandler<RefreshContainer, RefreshRequestedEventArgs> handler) where TElement : ElementType
    { element.RefreshRequested += handler; return element; }
    #endregion

}
