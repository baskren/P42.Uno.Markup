using ElementType = Microsoft.UI.Xaml.Controls.TreeViewItem;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace P42.Uno.Markup;

public static class TreeViewItemExtensions

{
    #region Properties
    public static TElement CollapsedGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    {
        element.CollapsedGlyph = value; return element;
    }

    public static TElement ExpandedGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    {
        element.ExpandedGlyph = value; return element;
    }

    #region GlyphBrush
    public static TElement GlyphBrush<TElement>(this TElement element, Brush brush) where TElement : ElementType
    { element.GlyphBrush = brush; return element; }

    public static TElement GlyphBrush<TElement>(this TElement element, Color color) where TElement : ElementType
    { element.GlyphBrush = new SolidColorBrush(color); return element; }

    public static TElement GlyphBrush<TElement>(this TElement element, string color) where TElement : ElementType
    { element.GlyphBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

    public static TElement GlyphBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
    { element.GlyphBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
    #endregion


    public static TElement GlyphOpacity<TElement>(this TElement element, double value) where TElement : ElementType
    {
        element.GlyphOpacity = value; return element;
    }

    public static TElement GlyphSize<TElement>(this TElement element, double value) where TElement : ElementType
    {
        element.GlyphSize = value; return element;
    }

    public static TElement HasUnrealizedChildren<TElement>(this TElement element, bool value = true) where TElement : ElementType
    {
        element.HasUnrealizedChildren = value; return element;
    }

    public static TElement IsExpanded<TElement>(this TElement element, bool value = true) where TElement : ElementType
    {
        element.IsExpanded = value; return element;
    }

    public static TElement ItemsSource<TElement>(this TElement element, object value) where TElement : ElementType
    {
        element.ItemsSource = value; return element;
    }
    #endregion


    #region Events
    #endregion
}
