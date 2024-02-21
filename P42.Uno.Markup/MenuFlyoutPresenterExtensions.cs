using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.MenuFlyoutPresenter;

namespace P42.Uno.Markup;
public static class MenuFlyoutPresenterExtensions
{

    public static TElement IsDefaultShadowEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsDefaultShadowEnabled = value; return element; }

}
