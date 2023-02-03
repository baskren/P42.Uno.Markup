using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using ElementType = Microsoft.UI.Xaml.Controls.AppBarSeparator;

namespace P42.Uno.Markup
{
    public static class AppBarSeparatorExtensions
    {
        #region Properties
        public static TElement DynamicOverflowOrder<TElement>(this TElement element, int value = default) where TElement : ElementType
        { element.DynamicOverflowOrder = value; return element; }

        public static TElement IsCompact<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsCompact = value; return element; }

        #endregion
    }
}