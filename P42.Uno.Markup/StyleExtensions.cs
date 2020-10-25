using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace P42.Uno.Markup
{
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
	}
}
