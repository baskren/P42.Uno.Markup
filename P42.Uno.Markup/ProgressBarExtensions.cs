using ElementType = Microsoft.UI.Xaml.Controls.ProgressBar;

namespace P42.Uno.Markup;
public static class ProgressBarExtensions
{

    public static TElement IsIndeterminate<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsIndeterminate = value; return element; }

    public static TElement ShowError<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.ShowError = value; return element; }

    public static TElement ShowPaused<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.ShowPaused = value; return element; }

}
