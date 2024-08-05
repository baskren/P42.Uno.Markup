using Microsoft.UI.Xaml;

namespace P42.Uno.Markup
{

	public static class StyleExtensions
	{
		public static Microsoft.UI.Xaml.Style Add(this Microsoft.UI.Xaml.Style element, DependencyProperty property, object value) 
		{
			element?.Setters.Add(new Setter(property, value));
			return element;
		}

		public static Microsoft.UI.Xaml.Style BasedOn(this Microsoft.UI.Xaml.Style element, Microsoft.UI.Xaml.Style source)
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
			Add(setters);
		}

		public Style<T> BasedOn(Style value)
		{
			FormsStyle.BasedOn = value;
			return this;
		}

		public Style<T> Add(params (DependencyProperty Property, object Value)[] setters)
		{
			foreach (var setter in setters)
			{
				FormsStyle.Setters.Add(new Setter(setter.Property, setter.Value));
			}
			return this;
		}

		public Style<T> Add(DependencyProperty Property, object Value)
		{
			FormsStyle.Setters.Add(new Setter(Property, Value));
			return this;
		}
	}
	


}


