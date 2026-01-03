using Windows.Foundation;

// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

/// <summary>
/// SemanticZoomLocation extensions
/// </summary>
// ReSharper disable once UnusedType.Global
public static class SemanticZoomLocationExtensions
{
    #region Bounds
    extension(SemanticZoomLocation semanticZoomLocation)
    {
        /// <summary>
        /// Bounds fluent setter
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public SemanticZoomLocation Bounds(double x, double y, double width, double height)
        { semanticZoomLocation.Bounds = new Rect(x,y,width,height); return semanticZoomLocation; }

        /// <summary>
        /// Bounds fluent setter
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public SemanticZoomLocation Bounds(Point point, Size size)
        { semanticZoomLocation.Bounds = new Rect(point, size); return semanticZoomLocation; }
    }

    #endregion

}
