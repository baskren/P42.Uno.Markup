using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;

namespace P42.Uno.Markup;
public static class SemanticZoomLocationExtensions
{
    #region Bounds
    public static SemanticZoomLocation Bounds(this SemanticZoomLocation semanticZoomLocation, Rect rect)
    {  semanticZoomLocation.Bounds = rect; return semanticZoomLocation; }

    public static SemanticZoomLocation Bounds(this SemanticZoomLocation semanticZoomLocation, double x, double y, double width, double height)
    { semanticZoomLocation.Bounds = new Rect(x,y,width,height); return semanticZoomLocation; }

    public static SemanticZoomLocation Bounds(this SemanticZoomLocation semanticZoomLocation, Point point, Size size)
    { semanticZoomLocation.Bounds = new Rect(point, size); return semanticZoomLocation; }
    #endregion

    public static SemanticZoomLocation BItemounds(this SemanticZoomLocation semanticZoomLocation, object item)
    { semanticZoomLocation.Item = item; return semanticZoomLocation; }


}
