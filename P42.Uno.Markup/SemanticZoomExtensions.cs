using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;
public static class SemanticZoomExtensions
{
    public static SemanticZoom CanChangeViews(this SemanticZoom semanticZoom, bool value = true)
    { semanticZoom.CanChangeViews = value; return semanticZoom; }

    public static SemanticZoom IsZoomedInViewActive(this SemanticZoom semanticZoom, bool value = true)
    { semanticZoom.IsZoomedInViewActive = value; return semanticZoom; }

    public static SemanticZoom IsZoomOutButtonEnabled(this SemanticZoom semanticZoom, bool value = true)
    { semanticZoom.IsZoomOutButtonEnabled = value; return semanticZoom; }

    public static SemanticZoom ZoomedInView(this SemanticZoom semanticZoom, ISemanticZoomInformation value)
    { semanticZoom.ZoomedInView = value; return semanticZoom; }

    public static SemanticZoom ZoomedOutView(this SemanticZoom semanticZoom, ISemanticZoomInformation value)
    { semanticZoom.ZoomedOutView = value; return semanticZoom; }

    #region Events
    public static SemanticZoom ViewChangeCompleted(this SemanticZoom semanticZoom, SemanticZoomViewChangedEventHandler handler)
    { semanticZoom.ViewChangeCompleted += handler; return semanticZoom; }

    public static SemanticZoom ViewChangeStarted(this SemanticZoom semanticZoom, SemanticZoomViewChangedEventHandler handler)
    { semanticZoom.ViewChangeStarted += handler; return semanticZoom; }
    #endregion
}
