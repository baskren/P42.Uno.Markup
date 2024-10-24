using ElementType = Microsoft.UI.Xaml.Controls.AppBarElementContainer;

namespace P42.Uno.Markup
{
    public static class AppBarElementContainerExtensions
    {
        #region Properties
        public static TElement DynamicOverflowOrder<TElement>(this TElement element, int value = default) where TElement : ElementType
        { element.DynamicOverflowOrder = value; return element; }

        public static TElement IsCompact<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsCompact = value; return element; }

        #endregion
    }
}