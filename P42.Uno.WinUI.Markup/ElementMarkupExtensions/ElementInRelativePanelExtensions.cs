using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ElementInRelativePanelExtensions
{
    /// <summary>
    /// Element in RelativePaenl Attached Properties Fluent extensions
    /// </summary>
    /// <param name="view"></param>
    /// <typeparam name="TView"></typeparam>
    // ReSharper disable once UnusedType.Global
    extension<TView>(TView view) where TView :ElementType
    {
        public TView Above(object otherElement)
        { RelativePanel.SetAbove(view, otherElement); return view; }

        public TView AlignBottomWith(object otherElement)
        { RelativePanel.SetAlignBottomWith(view, otherElement); return view; }

        public TView AlignBottomWithPanel(bool setAlignment = true)
        { RelativePanel.SetAlignBottomWithPanel(view, setAlignment); return view; }

        public TView AlignHorizontalCenterWith(object otherElement)
        { RelativePanel.SetAlignHorizontalCenterWith(view, otherElement); return view; }

        public TView AlignHorizontalCenterWithPanel(bool setAlignment = true)
        { RelativePanel.SetAlignHorizontalCenterWithPanel(view, setAlignment); return view; }

        public TView AlignLeftWith(object otherElement)
        { RelativePanel.SetAlignLeftWith(view, otherElement); return view; }

        public TView AlignLeftWithPanel(bool setAlignment = true)
        { RelativePanel.SetAlignLeftWithPanel(view, setAlignment); return view; }

        public TView AlignRightWith(object otherElement)
        { RelativePanel.SetAlignRightWith(view, otherElement); return view; }

        public TView AlignRightWithPanel(bool setAlignment = true)
        { RelativePanel.SetAlignRightWithPanel(view, setAlignment); return view; }

        public TView AlignTopWith(object otherElement)
        { RelativePanel.SetAlignTopWith(view, otherElement); return view; }

        public TView AlignTopWithPanel(bool setAlignment = true)
        { RelativePanel.SetAlignTopWithPanel(view, setAlignment); return view; }

        public TView AlignVerticalCenterWith(object otherElement)
        { RelativePanel.SetAlignVerticalCenterWith(view, otherElement); return view; }

        public TView AlignVerticalCenterWithPanel(bool setAlignment = true)
        { RelativePanel.SetAlignVerticalCenterWithPanel(view, setAlignment); return view; }

        public TView AlignCenterWithPanel(bool setAlignment = true)
        {
            RelativePanel.SetAlignVerticalCenterWithPanel(view, setAlignment);
            RelativePanel.SetAlignHorizontalCenterWithPanel(view, setAlignment);
            return view;
        }

        public TView Below(object otherElement)
        { RelativePanel.SetBelow(view, otherElement); return view; }

        public TView LeftOf(object otherElement)
        { RelativePanel.SetLeftOf(view, otherElement); return view; }

        public TView RightOf(object otherElement)
        { RelativePanel.SetRightOf(view, otherElement); return view; }
    }
}
