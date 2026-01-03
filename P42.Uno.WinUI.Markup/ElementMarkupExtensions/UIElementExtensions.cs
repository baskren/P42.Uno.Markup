using System.ComponentModel;
using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.UIElement;
using PeriodicTimer = P42.Utils.PeriodicTimer;

// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

// ReSharper disable once InconsistentNaming
public static class UIElementExtensions
{
    /// <summary>
    /// IsBlinking Dependency Property
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static readonly DependencyProperty IsBlinkingProperty = DependencyProperty.RegisterAttached(
        "IsBlinking",
        typeof(bool),
        typeof(UIElementExtensions),
        new PropertyMetadata(false));
        

    extension<TElement>(TElement element) where TElement : ElementType
    {
        #region Blinking
        
        
        private void SetIsBlinking(bool value) 
        {
            var isBlinking = element.GetIsBlinking();
            if (isBlinking == value)
                return;

            element.SetValue(IsBlinkingProperty, value);

            if (value)
            {
                PeriodicTimer.StartTimer(TimeSpan.FromSeconds(0.5), () =>
                {
                    try
                    {
                        if (!element.GetIsBlinking())
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
        private bool GetIsBlinking()
            => (bool)element.GetValue(IsBlinkingProperty);

        /// <summary>
        /// IsBlinking Extension Property
        /// </summary>
        public bool IsBlinking
        {
            get => element.GetIsBlinking();
            set => element.SetIsBlinking(value);
        }
        
        /// <summary>
        /// Blinking fluent method
        /// </summary>
        /// <param name="isBlinking"></param>
        /// <returns></returns>
        public TElement Blinking(bool isBlinking = true) 
        { element.SetIsBlinking(isBlinking); return element; }
        
        #endregion

        #region Visibility
        
        /// <summary>
        /// Visible fluent method
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public TElement Visible(bool visible = true)
        {
            element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
            return element;
        }

        /// <summary>
        /// Collapsed fluent method
        /// </summary>
        /// <param name="collapsed"></param>
        /// <returns></returns>
        public TElement Collapsed(bool collapsed = true)
        {
            element.Visibility = collapsed ? Visibility.Collapsed : Visibility.Visible;
            return element;
        }

        /// <summary>
        /// IsCollapsed Extension Property
        /// </summary>
        public bool IsCollapsed
        {
            get => element.Visibility ==  Visibility.Collapsed;
            set => element.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// Bind element's IsVisible to another of its DependencyProperty values
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public TElement BindVisible(DependencyProperty property)
        { element.AltBind(UIElement.VisibilityProperty, element, property, converter: VisibilityConverter.Instance); return element; }

        /// <summary>
        /// Bind element's IsVisible to another element's DependencyProperty values
        /// </summary>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public TElement BindVisible(DependencyObject source, DependencyProperty property)
        { element.AltBind(UIElement.VisibilityProperty, source, property, converter: VisibilityConverter.Instance); return element; }

        /// <summary>
        /// Bind element's IsVisible to a INotifyPropertyChanged element's property values
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public TElement BindVisible(INotifyPropertyChanged source, string path)
        { element.AltBind(UIElement.VisibilityProperty, source, path, converter: VisibilityConverter.Instance); return element; }

        /// <summary>
        /// Bind element's IsCollapsed to another of its DependencyProperty values
        /// </summary>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public TElement BindCollapsed(DependencyObject source, DependencyProperty property)
        { element.AltBind(UIElement.VisibilityProperty, source, property, converter: CollapsedConverter.Instance); return element; }

        /// <summary>
        /// Bind element's IsCollapsed to another element's DependencyProperty values
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public TElement BindCollapsed(DependencyProperty property)
        { element.AltBind(UIElement.VisibilityProperty, element, property, converter: CollapsedConverter.Instance); return element; }

        /// <summary>
        /// Bind element's IsCollapsed to a INotifyPropertyChanged element's property values
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public TElement BindCollapsed(INotifyPropertyChanged source, string path)
        { element.AltBind(UIElement.VisibilityProperty, source, path, converter: CollapsedConverter.Instance); return element; }

        #endregion

    }


}
