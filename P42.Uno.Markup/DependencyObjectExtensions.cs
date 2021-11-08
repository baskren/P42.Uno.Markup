using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace P42.Uno.Markup
{
    public static class DependencyObjectExtensions
    {
		public static TBindable Assign<TBindable, TVariable>(this TBindable bindable, out TVariable variable)
			where TBindable : DependencyObject, TVariable
		{
			variable = bindable;
			return bindable;
		}

		public static TBindable Invoke<TBindable>(this TBindable bindable, Action<TBindable> action) where TBindable : DependencyObject
		{
			action?.Invoke(bindable);
			return bindable;
		}

	}
}
