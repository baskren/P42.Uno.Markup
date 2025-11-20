namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ElementInCanvasExtensions
{
    public static TView LeftX<TView>(this TView view, double length) where TView : UIElement
    {
        view.SetValue(Canvas.LeftProperty, length);
        return view;
    }

    public static TView TopX<TView>(this TView view, double length) where TView : UIElement
    {
        view.SetValue(Canvas.TopProperty, length);
        return view;
    }

    public static TView ZIndexX<TView>(this TView view, int index) where TView : UIElement
    {
        view.SetValue(Canvas.ZIndexProperty, index);
        return view;
    }
}
