using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.Markup;

public static class ElementInRelativePanelExtensions
{
    public static TView AboveX<TView>(this TView view, object otherElement) where TView :ElementType
    { RelativePanel.SetAbove(view, otherElement); return view; }

    public static TView AlignBottomWithX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignBottomWith(view, otherElement); return view; }

    public static TView AlignBottomWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignBottomWithPanel(view, setAlignment); return view; }

    public static TView AlignHorizontalCenterWithX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignHorizontalCenterWith(view, otherElement); return view; }

    public static TView AlignHorizontalCenterWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignHorizontalCenterWithPanel(view, setAlignment); return view; }

    public static TView AlignLeftWithX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignLeftWith(view, otherElement); return view; }

    public static TView AlignLeftWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignLeftWithPanel(view, setAlignment); return view; }

    public static TView AlignRightWithX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignRightWith(view, otherElement); return view; }

    public static TView AlignRightWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignRightWithPanel(view, setAlignment); return view; }

    public static TView AlignTopWithX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignTopWith(view, otherElement); return view; }

    public static TView AlignTopWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignTopWithPanel(view, setAlignment); return view; }

    public static TView AlignVerticalCenterWithX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignVerticalCenterWith(view, otherElement); return view; }

    public static TView AlignVerticalCenterWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignVerticalCenterWithPanel(view, setAlignment); return view; }


    public static TView AlignCenterWithPanelX<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    {
        RelativePanel.SetAlignVerticalCenterWithPanel(view, setAlignment);
        RelativePanel.SetAlignHorizontalCenterWithPanel(view, setAlignment);
        return view;
    }

    public static TView BelowX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetBelow(view, otherElement); return view; }

    public static TView LeftOfX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetLeftOf(view, otherElement); return view; }

    public static TView RightOfX<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetRightOf(view, otherElement); return view; }

}
