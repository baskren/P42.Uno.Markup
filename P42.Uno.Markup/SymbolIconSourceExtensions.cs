using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.SymbolIconSource;

namespace P42.Uno.Markup
{
    public static class SymbolIconSourceExtensions
    {
        public static TElement Symbol<TElement>(this TElement element, Symbol symbol) where TElement : ElementType
        { element.Symbol = symbol; return element; }

    }
}