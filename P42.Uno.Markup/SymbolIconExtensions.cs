using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;

public static class SymbolIconExtensions
{
    public static SymbolIcon Symbol<TElement>(this SymbolIcon element, Symbol symbol) 
    { element.Symbol = symbol ; return element; }

}