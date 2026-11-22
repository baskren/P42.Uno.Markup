using ElementType = Microsoft.UI.Xaml.Controls.RadioButton;

namespace P42.Uno.Markup;

public static class RadioButtonExtensions
{
    #region Properties
    public static TElement GroupName<TElement>(this TElement element, string groupName = null) where TElement : ElementType
    { element.GroupName = groupName; return element; }
    #endregion
}