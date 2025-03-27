using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.Markup;

public static class ElementInRelativePanelExtensions
{
    public static TView Above<TView>(this TView view, object otherElement) where TView :ElementType
    { RelativePanel.SetAbove(view, otherElement); return view; }

    public static TView AlignBottomWith<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignBottomWith(view, otherElement); return view; }

    public static TView AlignBottomWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignBottomWithPanel(view, setAlignment); return view; }

    public static TView AlignHorizontalCenterWith<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignHorizontalCenterWith(view, otherElement); return view; }

    public static TView AlignHorizontalCenterWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignHorizontalCenterWithPanel(view, setAlignment); return view; }

    public static TView AlignLeftWith<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignLeftWith(view, otherElement); return view; }

    public static TView AlignLeftWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignLeftWithPanel(view, setAlignment); return view; }

    public static TView AlignRightWith<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignRightWith(view, otherElement); return view; }

    public static TView AlignRightWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignRightWithPanel(view, setAlignment); return view; }

    public static TView AlignTopWith<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignTopWith(view, otherElement); return view; }

    public static TView AlignTopWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignTopWithPanel(view, setAlignment); return view; }

    public static TView AlignVerticalCenterWith<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetAlignVerticalCenterWith(view, otherElement); return view; }

    public static TView AlignVerticalCenterWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    { RelativePanel.SetAlignVerticalCenterWithPanel(view, setAlignment); return view; }


    public static TView AlignCenterWithPanel<TView>(this TView view, bool setAlignment = true) where TView : ElementType
    {
        RelativePanel.SetAlignVerticalCenterWithPanel(view, setAlignment);
        RelativePanel.SetAlignHorizontalCenterWithPanel(view, setAlignment);
        return view;
    }

    public static TView Below<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetBelow(view, otherElement); return view; }

    public static TView LeftOf<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetLeftOf(view, otherElement); return view; }

    public static TView RightOf<TView>(this TView view, object otherElement) where TView : ElementType
    { RelativePanel.SetRightOf(view, otherElement); return view; }

}