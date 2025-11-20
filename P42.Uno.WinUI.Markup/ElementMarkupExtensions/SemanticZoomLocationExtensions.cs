using Windows.Foundation;

namespace P42.Uno.WinUI.Markup;
// ReSharper disable once UnusedType.Global
public static class SemanticZoomLocationExtensions
{
    #region Bounds
    public static SemanticZoomLocation Bounds(this SemanticZoomLocation semanticZoomLocation, double x, double y, double width, double height)
    { semanticZoomLocation.Bounds = new Rect(x,y,width,height); return semanticZoomLocation; }

    public static SemanticZoomLocation Bounds(this SemanticZoomLocation semanticZoomLocation, Point point, Size size)
    { semanticZoomLocation.Bounds = new Rect(point, size); return semanticZoomLocation; }
    #endregion

}
