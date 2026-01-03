// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

public static partial class StyleExtensions
{
    extension(Style element)
    {
        /// <summary>
        /// Adds a Property+Value setter to a Style
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Style Add(DependencyProperty property, object value)
        {
            element.Setters.Add(new Setter(property, value));
            return element;
        }

        
        /// <summary>
        /// BasedOn fluent setter
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Style BasedOn(Style source)
        {
            element.BasedOn = source;
            return element;
        }
        
    }
}

	
/// <summary>
/// Generic Style (for strong typing)
/// </summary>
/// <typeparam name="T"></typeparam>
public class Style<T> where T : DependencyObject
{
    /// <summary>
    /// Implicit conversion to Style
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    public static implicit operator Style(Style<T> style) => style.BaseStyle;

    /// <summary>
    /// Foundational, non-generic style
    /// </summary>
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public Style BaseStyle { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="setters"></param>
    public Style(params (DependencyProperty Property, object Value)[] setters)
    {
        BaseStyle = new Style(typeof(T));
        Add(setters);
    }

    /// <summary>
    /// BasedOn fluent Setter
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Style<T> BasedOn(Style value)
    {
        BaseStyle.BasedOn = value;
        return this;
    }

    /// <summary>
    /// Add Property/Value pairs
    /// </summary>
    /// <param name="setters"></param>
    /// <returns></returns>
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public Style<T> Add(params (DependencyProperty Property, object Value)[] setters)
    {
        foreach (var setter in setters)
        {
            BaseStyle.Setters.Add(new Setter(setter.Property, setter.Value));
        }
        return this;
    }


    /// <summary>
    /// Add Property/Value pair
    /// </summary>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public Style<T> Add(DependencyProperty property, object value)
    {
        BaseStyle.Setters.Add(new Setter(property, value));
        return this;
    }
}
