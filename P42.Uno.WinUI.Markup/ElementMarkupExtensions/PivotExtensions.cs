namespace P42.Uno.WinUI.Markup;
// ReSharper disable once UnusedType.Global
public static class PivotExtensions
{
    
    #region Attached Properties
    public static TElement SlideInAnimationGroup<TElement>(this TElement element, PivotSlideInAnimationGroup value) where TElement : FrameworkElement
    { Pivot.SetSlideInAnimationGroup(element, value); return element; }
    #endregion

}
