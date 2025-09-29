using Microsoft.UI.Xaml;

namespace P42.Uno.Markup;

public static class StyleExtensions
{
    public static Style Add(this Style element, DependencyProperty property, object value) 
    {
        element?.Setters.Add(new Setter(property, value));
        return element;
    }

    public static Style BasedOn(this Style element, Style source)
    {
        element.BasedOn = source;
        return element;
    }
}

	
public class Style<T> where T : DependencyObject
{
    public static implicit operator Style(Style<T> style) => style?.FormsStyle;

    public Style FormsStyle { get; }

    public Style(params (DependencyProperty Property, object Value)[] setters)
    {
        FormsStyle = new Style(typeof(T)) { };
        AddX(setters);
    }

    public Style<T> BasedOnX(Style value)
    {
        FormsStyle.BasedOn = value;
        return this;
    }

    public Style<T> AddX(params (DependencyProperty Property, object Value)[] setters)
    {
        foreach (var setter in setters)
        {
            FormsStyle.Setters.Add(new Setter(setter.Property, setter.Value));
        }
        return this;
    }

    public Style<T> AddX(DependencyProperty Property, object Value)
    {
        FormsStyle.Setters.Add(new Setter(Property, Value));
        return this;
    }
}
