using ElementType = Microsoft.UI.Xaml.UIElement;
using System.ComponentModel;
using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once InconsistentNaming
public static class UIElementExtensions
{
    #region Blinking
        
    public static readonly DependencyProperty IsBlinkingProperty = DependencyProperty.RegisterAttached(
        "IsBlinking",
        typeof(bool),
        typeof(UIElementExtensions),
        new PropertyMetadata(false));
        
    public static void SetIsBlinking(ElementType element, bool value) 
    {
        var isBlinking = GetIsBlinking(element);
        if (isBlinking == value)
            return;

        element.SetValue(IsBlinkingProperty, value);

        if (value)
        {
            Utils.PeriodicTimer.StartTimer(TimeSpan.FromSeconds(0.5), () =>
            {
                try
                {
                    if (!GetIsBlinking(element))
                    {
                        element.Opacity = 1;
                        return false;
                    }
                    element.Opacity = element.Opacity >= 1
                        ? 0.25
                        : 1;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
    }
    public static bool GetIsBlinking(UIElement element)
        => (bool)element.GetValue(IsBlinkingProperty);
        
    public static TElement Blinking<TElement>(this TElement element, bool isBlinking = true) where TElement :ElementType
    { SetIsBlinking(element, isBlinking); return element; }
        
    #endregion
        
    #region Visibility

    public static TElement Visible<TElement>(this TElement element, bool visible = true) where TElement : ElementType
    {
        element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        return element;
    }

    public static TElement Collapsed<TElement>(this TElement element, bool collapsed = true)
        where TElement : ElementType
    {
        element.Visibility = collapsed ? Visibility.Collapsed : Visibility.Visible;
        return element;
    }
    
    public static TElement BindVisible<TElement>(this TElement element, DependencyProperty property) where TElement : ElementType
    { element.AltBind(UIElement.VisibilityProperty, element, property, converter: VisibilityConverter.Instance); return element; }

    public static TElement BindVisible<TElement>(this TElement element, DependencyObject source, DependencyProperty property) where TElement : ElementType
    { element.AltBind(UIElement.VisibilityProperty, source, property, converter: VisibilityConverter.Instance); return element; }

    public static TElement BindVisible<TElement>(this TElement element, INotifyPropertyChanged source, string path) where TElement : ElementType
    { element.AltBind(UIElement.VisibilityProperty, source, path, converter: VisibilityConverter.Instance); return element; }

    public static TElement BindCollapsed<TElement>(this TElement element, DependencyObject source, DependencyProperty property) where TElement : ElementType
    { element.AltBind(UIElement.VisibilityProperty, source, property, converter: CollapsedConverter.Instance); return element; }

    public static TElement BindCollapsed<TElement>(this TElement element, DependencyProperty property) where TElement : ElementType
    { element.AltBind(UIElement.VisibilityProperty, element, property, converter: CollapsedConverter.Instance); return element; }

    public static TElement BindCollapsed<TElement>(this TElement element, INotifyPropertyChanged source, string path) where TElement : ElementType
    { element.AltBind(UIElement.VisibilityProperty, source, path, converter: CollapsedConverter.Instance); return element; }

    #endregion

}
