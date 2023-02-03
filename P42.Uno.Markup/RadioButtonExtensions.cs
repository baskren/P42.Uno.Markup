using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.RadioButton;

namespace P42.Uno.Markup
{
    public static class RadioButtonExtensions
    {
        #region Properties
        public static TElement GroupName<TElement>(this TElement element, string groupName = null) where TElement : ElementType
        { element.GroupName = groupName; return element; }
        #endregion
    }
}