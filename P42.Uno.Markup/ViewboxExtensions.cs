using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup;

public static class ViewboxExtensions
{
    #region Properties

    public static Viewbox Child(this Viewbox element, UIElement child) 
    { element.Child = child; return element; }

    public static Viewbox Stretch(this Viewbox element, Stretch value)
    { element.Stretch = value; return element; }

    public static Viewbox StretchDirection(this Viewbox element, StretchDirection value) 
    { element.StretchDirection = value; return element; }

    #endregion



}
