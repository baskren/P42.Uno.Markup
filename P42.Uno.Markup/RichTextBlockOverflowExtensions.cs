using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;
public static class RichTextBlockOverflowExtensions
{

    public static RichTextBlockOverflow MaxLines(this RichTextBlockOverflow element, int value)
    { element.MaxLines = value; return element; }

    public static RichTextBlockOverflow OverflowContentTarget(this RichTextBlockOverflow element, RichTextBlockOverflow value)
    { element.OverflowContentTarget = value; return element; }

    #region Padding
    public static RichTextBlockOverflow Padding(this RichTextBlockOverflow element, double value)
    { element.Padding = new Thickness(value); return element; }

    public static RichTextBlockOverflow Padding(this RichTextBlockOverflow element, double horizontal, double vertical)
    { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

    public static RichTextBlockOverflow Padding(this RichTextBlockOverflow element, double left, double top, double right, double bottom)
    { element.Padding = new Thickness(left, top, right, bottom); return element; }

    public static RichTextBlockOverflow Padding(this RichTextBlockOverflow element, Thickness padding)
    { element.Padding = padding; return element; }
    #endregion


}
