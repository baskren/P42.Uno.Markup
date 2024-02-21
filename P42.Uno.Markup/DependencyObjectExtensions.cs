using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using P42.Serilog.QuickLog;
using ElementType = Microsoft.UI.Xaml.DependencyObject;

namespace P42.Uno.Markup
{
    public static class DependencyObjectExtensions
    {
        #region IsEnabled
        public static readonly DependencyProperty IsEnabledProperty =
			DependencyProperty.RegisterAttached("IsEnabled", typeof(string), typeof(DependencyObjectExtensions), new PropertyMetadata(null, IsEnabledChanged));

        public static DependencyObject SetIsEnabled(this DependencyObject dependencyObject, bool value = true)
        {
            dependencyObject.SetValue(IsEnabledProperty, value);
            return dependencyObject;
        }


        public static bool GetIsEnabled(this DependencyObject dependencyObject)
            => (bool)dependencyObject.GetValue(IsEnabledProperty);


        public static ElementType IsEnabled(this ElementType element, bool value = true)
        { element.SetIsEnabled(value); return element; }

        public static TElement BindIsEnabled<TElement>(this TElement element, object source, string path,
            BindingMode mode = BindingMode.OneWay,
            IValueConverter converter = null,
            object converterParameter = null,
            string converterLanguage = null,
            UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
            object targetNullValue = null,
            object fallbackValue = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1
            ) where TElement : ElementType
        {
            element.Bind(IsEnabledProperty, source, path, mode, converter, converterParameter, converterLanguage, updateSourceTrigger, targetNullValue, fallbackValue, filePath, lineNumber);
            return element;
        }

        private static void IsEnabledChanged(ElementType dependencyObject, DependencyPropertyChangedEventArgs args)
        {
			if (args is null || dependencyObject is null)
				return;

            if (args.NewValue is not bool newValue)
                newValue = true;

            if (dependencyObject is Control control)
                control.IsEnabled = (bool)BooleanConverter.Instance.Convert(args.NewValue);
            else
            {
                var count = VisualTreeHelper.GetChildrenCount(dependencyObject);
                for (int i = 0; i < count; i++)
				{
                    var current = VisualTreeHelper.GetChild(dependencyObject, i);
                    if (current is Panel panel)
					{
						foreach (var child in panel.Children)
                            IsEnabledChanged(child, args);
					}
				}
			}

        }
        #endregion IsEnabled

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

        #region Property Changed Handler
        public static TElement AddPropertyChangedHandler<TElement>(this TElement element, DependencyProperty property, DependencyPropertyChangedCallback handler) where TElement : ElementType
        {
            element.RegisterPropertyChangedCallback(property, handler);
            return element;
        }
        #endregion


        #region Bind
        static void CheckArguments<TBindable>(this TBindable target, DependencyProperty targetProperty, object source, string path, IValueConverter converter, object converterParameter, string converterLanguage, string filePath, int lineNumber) where TBindable : DependencyObject
		{
			try
			{
				CheckPropertyTarget(target, targetProperty, filePath, lineNumber);


				if (source is null)
				{
					//var msg = $"BIND: Source is null when Bind() is called.  Cannot check if Target Property type matches Source Property type.";
					//Console.WriteLine(msg);
					//Debug.WriteLine(msg);
					return;
				}

#if HAS_UNO
				var dependencyPropertyType = typeof(DependencyProperty);
				var targetPropertyNameField = dependencyPropertyType.GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
				var targetPropertyValueTypeField = dependencyPropertyType.GetField("_propertyType", BindingFlags.NonPublic | BindingFlags.Instance);
				var targetPropertyOwnerTypeField = dependencyPropertyType.GetField("_ownerType", BindingFlags.NonPublic | BindingFlags.Instance);

				var targetPropertyType = (Type)targetPropertyValueTypeField.GetValue(targetProperty);
#else
				var targetPropertyType = target.GetValue(targetProperty)?.GetType();
#endif
                if (targetPropertyType is null)
				{
                    //var msg = $"BIND: Target Property is null when Bind() is called.  Cannot check if Target Property type matches Source Property type.";
                    //Console.WriteLine(msg);
                    //Debug.WriteLine(msg);
                    return;
                }

                var sourceClassType = source.GetType();
				var sourceValueType = sourceClassType;
				var sourceLabel = sourceClassType.ToString();
				if (path is not null)
				{
					sourceValueType = sourceClassType.GetProperties().Where(p=>p.Name == path).FirstOrDefault()?.PropertyType;
					if (sourceValueType is null)
						throw new ArgumentNullException($"No property found at {sourceClassType}.{path}.  {filePath}:{lineNumber}");
					sourceLabel = $"{sourceClassType}.{path}";
				}

				if (converter is not null)
				{
					if (targetPropertyType is null)
						return;

					object sourceDefaultValue = sourceValueType.IsValueType
						? Activator.CreateInstance(sourceValueType)
						: null;

					object converterDefaultValue = converter.Convert(sourceDefaultValue, targetPropertyType, converterParameter, converterLanguage);
                    CheckTypeMatch(targetPropertyType, converterDefaultValue.GetType(), "TargetProperty", "Converter result", filePath, lineNumber);
                }
                else
					CheckTypeMatch(targetPropertyType, sourceValueType, "TargetProperty", sourceLabel, filePath, lineNumber);
			}
			catch (Exception ex)
			{
				QLog.Debug(ex);
			}
        }

		static FieldInfo FlagsAttachedField;
        static void CheckPropertyTarget<TBindable>(this TBindable target, DependencyProperty targetProperty, string filePath, int lineNumber) where TBindable : DependencyObject
		{
#if !WINDOWS
            FlagsAttachedField ??= typeof(DependencyProperty).GetField("_flags", BindingFlags.Instance | BindingFlags.NonPublic);
			if (FlagsAttachedField != null && FlagsAttachedField.GetValue(targetProperty) is int flags && flags % 2 == 1)
				return;
#endif
			if (!CheckTypeMatch(target.GetType(), target, targetProperty, filePath, lineNumber))
            {
                var msg = $"BIND: TargetProperty is not member of targetClass [{target.GetType()}]. This is ok if TargetProperty is an Attached Property.  {filePath}:{lineNumber}";
                Console.WriteLine(msg);
                Debug.WriteLine(msg);
            }

        }

		static int LastLine([CallerLineNumber] int lineNumber = -1)
			=> lineNumber < 0 ? -1 : lineNumber;

        static bool CheckTypeMatch<TBindable>(Type targetType, TBindable target, DependencyProperty targetProperty, string filePath, int lineNumber) where TBindable : DependencyObject
        {
			//Debug.WriteLine($"targetType [{targetType}] : property = [{targetProperty}]");
			if (targetType is null)
				return false;

			var lastLine = -1;

			try
			{
				var found = false;

				if (!found)
				{
					lastLine = LastLine();
					var properties = targetType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? Array.Empty<PropertyInfo>();
                    lastLine = LastLine();
                    foreach (var property in properties)
					{
                        lastLine = LastLine();
                        if (property.PropertyType == typeof(DependencyProperty))
						{
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                            lastLine = LastLine();
                            if (property.GetValue(target) == targetProperty)
								return true;
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
						}
					}
				}

                lastLine = LastLine();
                if (!found)
				{
                    lastLine = LastLine();
                    var fields = targetType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? Array.Empty<FieldInfo>();
                    lastLine = LastLine();
                    foreach (var field in fields)
					{
                        lastLine = LastLine();
                        if (field.FieldType == typeof(DependencyProperty))
						{
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                            lastLine = LastLine();
                            if (field.GetValue(target) == targetProperty)
								return true;
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
						}
					}

				}

                lastLine = LastLine();
                if (targetType == typeof(DependencyObject))
					return false;

                lastLine = LastLine();
                return CheckTypeMatch(targetType.BaseType, target, targetProperty, filePath, lineNumber);
			}
			catch (Exception ex)
			{
                var msg = $"BIND.CheckTypeMatch({targetType}, {target}, {targetProperty}, {filePath}, {lineNumber}) : LastLine [{lastLine}] Exception: [{ex.Message}][{ex.Source}[{ex.StackTrace}]]";
                Console.WriteLine(msg);
                Debug.WriteLine(msg);

                return false;
			}
        }

		static void CheckTypeMatch(Type targetPropertyType, Type sourceType, string targetLabel, string sourceLabel,  string filePath, int lineNumber)
		{
			if (targetPropertyType is null)
				return;

			if (!targetPropertyType.IsAssignableFrom(sourceType))
			{
				var msg = $"BIND: {targetLabel} type [{targetPropertyType}] is not assignable from the type [{sourceType}] found at {sourceLabel}.  This can be a false detection in Windows platform apps.  {filePath}:{lineNumber}";
                Console.WriteLine(msg);
                Debug.WriteLine(msg);
            }
        }

        //const string bindingContextPath = Binding.SelfPath;

        /// <summary>Bind to a specified property</summary>
        public static TBindable Bind<TBindable>(
			this TBindable target,
			DependencyProperty targetProperty,
			object source,
			string path = null,
			BindingMode mode = BindingMode.OneWay,
			IValueConverter converter = null,
			object converterParameter = null,
			string converterLanguage = null,
			UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
			object targetNullValue = null,
			object fallbackValue = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1
		) where TBindable : DependencyObject
		{
			CheckArguments(target, targetProperty, source, path, converter, converterParameter, converterLanguage, filePath, lineNumber);

            var binding = new Binding
			{
				Source = source,
				Mode = mode,
				Converter = converter,
				ConverterParameter = converterParameter,
				UpdateSourceTrigger = updateSourceTrigger,
				TargetNullValue = targetNullValue,
				FallbackValue = fallbackValue
			};
			if (!string.IsNullOrWhiteSpace(converterLanguage))
				binding.ConverterLanguage = converterLanguage;
			if (!string.IsNullOrWhiteSpace(path))
				binding.Path = new PropertyPath(path);
			BindingOperations.SetBinding(target, targetProperty, binding);

			return target;
		}

		/// <summary>Bind to a specified property with inline conversion</summary>
		public static TBindable Bind<TBindable, TSource, TDest>(
			this TBindable target,
			DependencyProperty targetProperty,
			object source = null,
			string path = null,
			BindingMode mode = BindingMode.OneWay,
			Func<TSource, TDest> convert = null,
			Func<TDest, TSource> convertBack = null,
			object converterParameter = null,
			string converterLanguage = null,
			UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
			object targetNullValue = null,
			object fallbackValue = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1
        ) where TBindable : DependencyObject
		{
            var converter = new FuncConverter<TSource, TDest, object>(convert, convertBack, filePath, lineNumber);
            CheckArguments(target, targetProperty, source, path, converter, converterParameter, converterLanguage, filePath, lineNumber);

			var binding = new Binding
			{
				Source = source,
				Mode = mode,
				Converter = converter,
				ConverterParameter = converterParameter,
				UpdateSourceTrigger = updateSourceTrigger,
				TargetNullValue = targetNullValue,
				FallbackValue = fallbackValue
			};
			if (!string.IsNullOrWhiteSpace(converterLanguage))
				binding.ConverterLanguage = converterLanguage;
			if (!string.IsNullOrWhiteSpace(path))
				binding.Path = new PropertyPath(path);
			BindingOperations.SetBinding(target, targetProperty, binding);
			return target;
		}

		/// <summary>Bind to a specified property with inline conversion and conversion parameter</summary>
		public static TBindable Bind<TBindable, TSource, TParam, TDest>(
			this TBindable target,
			DependencyProperty targetProperty,
			object source = null,
			string path = null,
			BindingMode mode = BindingMode.OneWay,
			Func<TSource, TParam, TDest> convert = null,
			Func<TDest, TParam, TSource> convertBack = null,
			object converterParameter = null,
			string converterLanguage = null,
			UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
			object targetNullValue = null,
			object fallbackValue = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1
        ) where TBindable : DependencyObject
		{
            var converter = new FuncConverter<TSource, TDest, TParam>(convert, convertBack, filePath, lineNumber);
            CheckArguments(target, targetProperty, source, path, converter, converterParameter, converterLanguage, filePath, lineNumber);

            var binding = new Binding
			{
				Source = source,
				Mode = mode,
				Converter = converter,
				ConverterParameter = converterParameter,
				UpdateSourceTrigger = updateSourceTrigger,
				TargetNullValue = targetNullValue,
				FallbackValue = fallbackValue
			};
			if (!string.IsNullOrWhiteSpace(converterLanguage))
				binding.ConverterLanguage = converterLanguage;
			if (!string.IsNullOrWhiteSpace(path))
				binding.Path = new PropertyPath(path);
			BindingOperations.SetBinding(target, targetProperty, binding);
			return target;
		}
        #endregion

        /*
		/// <summary>Bind to the default property</summary>
		public static TBindable Bind<TBindable>(
			this TBindable bindable,
			string path = bindingContextPath,
			BindingMode mode = BindingMode.OneWay,
			IValueConverter converter = null,
			object converterParameter = null,
			string stringFormat = null,
			object source = null,
			object targetNullValue = null,
			object fallbackValue = null
		) where TBindable : DependencyObject
		{
			bindable.Bind(
				DefaultBindableProperties.GetFor(bindable),
				path, mode, converter, converterParameter, stringFormat, source, targetNullValue, fallbackValue
			);
			return bindable;
		}

		/// <summary>Bind to the default property with inline conversion</summary>
		public static TBindable Bind<TBindable, TSource, TDest>(
			this TBindable bindable,
			string path = bindingContextPath,
			BindingMode mode = BindingMode.OneWay,
			Func<TSource, TDest> convert = null,
			Func<TDest, TSource> convertBack = null,
			object converterParameter = null,
			string stringFormat = null,
			object source = null,
			object targetNullValue = null,
			object fallbackValue = null
		) where TBindable : DependencyObject
		{
			var converter = new FuncConverter<TSource, TDest, object>(convert, convertBack);
			bindable.Bind(
				DefaultBindableProperties.GetFor(bindable),
				path, mode, converter, converterParameter, stringFormat, source, targetNullValue, fallbackValue
			);
			return bindable;
		}

		/// <summary>Bind to the default property with inline conversion and conversion parameter</summary>
		public static TBindable Bind<TBindable, TSource, TParam, TDest>(
			this TBindable bindable,
			string path = bindingContextPath,
			BindingMode mode = BindingMode.OneWay,
			Func<TSource, TParam, TDest> convert = null,
			Func<TDest, TParam, TSource> convertBack = null,
			object converterParameter = null,
			string stringFormat = null,
			object source = null,
			object targetNullValue = null,
			object fallbackValue = null
		) where TBindable : DependencyObject
		{
			var converter = new FuncConverter<TSource, TDest, TParam>(convert, convertBack);
			bindable.Bind(
				DefaultBindableProperties.GetFor(bindable),
				path, mode, converter, converterParameter, stringFormat, source, targetNullValue, fallbackValue
			);
			return bindable;
		}

		/// <summary>Bind to the <typeparamref name="TBindable"/>'s default Command and CommandParameter properties </summary>
		/// <param name="parameterPath">If null, no binding is created for the CommandParameter property</param>
		public static TBindable BindCommand<TBindable>(
			this TBindable bindable,

			string path = bindingContextPath,
			object source = null,
			string parameterPath = bindingContextPath,
			object parameterSource = null
		) where TBindable : DependencyObject
		{
			(var commandProperty, var parameterProperty) = DefaultBindableProperties.GetForCommand(bindable);

			bindable.SetBinding(commandProperty, new Binding(path: path, source: source));

			if (parameterPath != null)
				bindable.SetBinding(parameterProperty, new Binding(path: parameterPath, source: parameterSource));

			return bindable;
		}
		*/


    }
}
