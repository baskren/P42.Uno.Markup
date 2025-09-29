using System;
using System.Numerics;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Media3D;
using ElementType = Microsoft.UI.Xaml.UIElement;
using System.ComponentModel;
//using P42.Utils.Uno;

namespace P42.Uno.Markup;

public static class UIElementExtensions
{
    #region Blinking
        
    public static DependencyProperty IsBlinkingProperty = DependencyProperty.RegisterAttached(
        "IsBlinking",
        typeof(Boolean),
        typeof(UIElementExtensions),
        new PropertyMetadata(false));
        
    public static void SetIsBlinking(UIElement element, Boolean value) 
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
                    element.Opacity = element.Opacity == 1
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

    public static TElement BindVisible<TElement>(this TElement element, DependencyProperty property) where TElement : ElementType
    { element.WBind(UIElement.VisibilityProperty, element, property, converter: VisibilityConverter.Instance); return element; }

    public static TElement BindVisible<TElement>(this TElement element, DependencyObject source, DependencyProperty property) where TElement : ElementType
    { element.WBind(UIElement.VisibilityProperty, source, property, converter: VisibilityConverter.Instance); return element; }

    public static TElement BindVisible<TElement>(this TElement element, INotifyPropertyChanged source, string path) where TElement : ElementType
    { element.WBind(UIElement.VisibilityProperty, source, path, converter: VisibilityConverter.Instance); return element; }

    public static TElement BindCollapsed<TElement>(this TElement element, DependencyObject source, DependencyProperty property) where TElement : ElementType
    { element.WBind(UIElement.VisibilityProperty, source, property, converter: CollapsedConverter.Instance); return element; }

    public static TElement BindCollapsed<TElement>(this TElement element, DependencyProperty property) where TElement : ElementType
    { element.WBind(UIElement.VisibilityProperty, element, property, converter: CollapsedConverter.Instance); return element; }

    public static TElement BindCollapsed<TElement>(this TElement element, INotifyPropertyChanged source, string path) where TElement : ElementType
    { element.WBind(UIElement.VisibilityProperty, source, path, converter: CollapsedConverter.Instance); return element; }

    #endregion

    /*
    #region DataTemplate
    internal static string AsDataTemplateXaml(this Type templateType)
    {
        if (templateType == null || !typeof(FrameworkElement).IsAssignableFrom(templateType))
            throw new Exception($"Cannot convert type [{templateType}] into DataTemplate");
        var markup = string.Empty;
        //if (dataType is null)
        markup = $"<DataTemplate \n\t xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" \n\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n\t xmlns:local=\"using:{templateType.Namespace}\"> \n\t\t<local:{templateType.Name} /> \n</DataTemplate>";
        //if (dataType.Namespace == typeof(Type).Namespace)
        //    markup = $"<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:tlocal=\"using:{templateType.Namespace}\" xmlns:system=\"using:System\" x:DataType=\"system:{dataType.Name}\"><tlocal:{templateType.Name} /></DataTemplate>";
        //else
        //    markup = $"<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" \n\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n\t xmlns:tlocal=\"using:{templateType.Namespace}\" \n\t xmlns:dlocal=\"using:{dataType.Namespace}\" \n\t x:DataType=\"dlocal:{dataType.Name}\"> \n\t\t<tlocal:{templateType.Name} /> \n</DataTemplate>";
        System.Diagnostics.Debug.WriteLine($"BcGroupView.GenerateDatatemplate: markup: {markup}");
        //template.
        return markup;
    }

    internal static DataTemplate AsDataTemplate(this Type templateType)
    {
        try
        {
            if (templateType == null || !typeof(FrameworkElement).IsAssignableFrom(templateType))
                throw new Exception($"Cannot convert type [{templateType}] into DataTemplate");
            var markup = $"<DataTemplate \n\t xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" \n\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n\t xmlns:local=\"using:{templateType.Namespace}\"> \n\t\t<local:{templateType.Name} /> \n</DataTemplate>";
            //System.Diagnostics.Trace.WriteLine($"AsDataTemplate : [{markup}]");
            var template = (DataTemplate)XamlReader.Load(markup);
            //template.
            return template;
        }
        catch (Exception e)
        {
            //System.Console.WriteLine($"EXCEPTION [{e.Message}] [{e.StackTrace}]");
            System.Diagnostics.Trace.WriteLine($"EXCEPTION [{e.Message}] [{e.StackTrace}]");
        }
        return null;
    }
    #endregion
    */

}
