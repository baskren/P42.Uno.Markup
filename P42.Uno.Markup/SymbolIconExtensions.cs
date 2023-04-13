using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.SymbolIcon;

namespace P42.Uno.Markup
{
    public static class SymbolIconExtensions
    {
        public static SymbolIcon Symbol<TElement>(this SymbolIcon element, Symbol symbol) 
        { element.Symbol = symbol ; return element; }

    }
}