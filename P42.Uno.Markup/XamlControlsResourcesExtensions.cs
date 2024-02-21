using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.XamlControlsResources;

namespace P42.Uno.Markup;
public static class XamlControlsResourcesExtensions
{

    public static ElementType UseCompactResources(this ElementType element, bool value = true)
    { element.UseCompactResources = value; return element; }
}
