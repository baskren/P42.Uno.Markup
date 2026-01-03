using System.ComponentModel;
using System.Runtime.CompilerServices;
using P42.Utils.Uno;
using ElementType = Microsoft.UI.Xaml.DependencyObject;

// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

public static class DependencyObjectExtensions
{
    #region IsEnabled
    public static readonly DependencyProperty IsEnabledXProperty =
        DependencyProperty.RegisterAttached("IsEnabled", typeof(string), typeof(DependencyObjectExtensions), new PropertyMetadata(null, IsEnabledChanged));
    private static void IsEnabledChanged(ElementType dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        if (args.NewValue is not bool newValue)
            newValue = true;

        if (dependencyObject is Control control)
            control.IsEnabled = (bool)(BooleanConverter.Instance.Convert(newValue) ?? false);
        else
        {
            var count = VisualTreeHelper.GetChildrenCount(dependencyObject);
            for (var i = 0; i < count; i++)
            {
                var current = VisualTreeHelper.GetChild(dependencyObject, i);
                if (current is not Panel panel)
                    continue;

                foreach (var child in panel.Children)
                    IsEnabledChanged(child, args);
            }
        }

    }

    extension(ElementType dependencyObject)
    {

        public bool IsEnabled
        {
            get => (bool)dependencyObject.GetValue(IsEnabledXProperty);
            set => dependencyObject.SetValue(IsEnabledXProperty, value);
        }
        
        public ElementType Enabled(bool value = true)
        { dependencyObject.IsEnabled = value; return dependencyObject; }
        
        public ElementType Disabled(bool value = true)
        { dependencyObject.IsEnabled = !value; return dependencyObject; }
    }

    extension<TElement>(TElement target) where TElement : ElementType
    {
        public TElement BindIsEnabled(DependencyObject source,
            DependencyProperty sourceProperty,
            BindingMode mode = BindingMode.OneWay,
            IValueConverter? converter = null,
            object? converterParameter = null,
            string? converterLanguage = null,
            UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
            object? targetNullValue = null,
            object? fallbackValue = null,
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1
        ) => target.AltBind(IsEnabledXProperty, source, sourceProperty, mode, converter, converterParameter, converterLanguage, updateSourceTrigger, targetNullValue, fallbackValue, filePath, lineNumber);

        public TElement BindIsEnabled<TSource, TDest>(INotifyPropertyChanged source,
            string sourcePropertyName,
            BindingMode mode = BindingMode.OneWay,
            Func<TSource?, TDest?>? convert = null,
            Func<TDest?, TSource?>? convertBack = null,
            object? converterParameter = null,
            string? converterLanguage = null,
            UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
            object? targetNullValue = null,
            object? fallbackValue = null, 
            [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1
        )
            where TSource : notnull
            where TDest : notnull
        {
            target.AltBind(IsEnabledXProperty, source, sourcePropertyName, mode, convert, convertBack, converterParameter, converterLanguage, updateSourceTrigger, targetNullValue, fallbackValue, filePath, lineNumber);
            return target;
        }
    }

    #endregion IsEnabled

    
    extension<TElement>(TElement element) where TElement : ElementType
    {
        public TElement Invoke(Action<TElement> action)
        {
            action.Invoke(element);
            return element;
        }

        public TElement AddPropertyChangedHandler(DependencyProperty property,
            DependencyPropertyChangedCallback handler)
        {
            element.RegisterPropertyChangedCallback(property, handler);
            return element;

        }
    }


    
    /*
    #region Bind

    private static void CheckArguments<TBindable>(this TBindable target, DependencyProperty targetProperty, object source, string path, IValueConverter converter, object converterParameter, string converterLanguage, string filePath, int lineNumber) where TBindable : DependencyObject
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

                try
                {
                    var sourceDefaultValue = sourceValueType.IsValueType
                        ? Activator.CreateInstance(sourceValueType)
                        : null;

                    var converterDefaultValue = converter.Convert(sourceDefaultValue, targetPropertyType, converterParameter, converterLanguage);
                    CheckTypeMatch(targetPropertyType, converterDefaultValue.GetType(), "TargetProperty", "Converter result", filePath, lineNumber);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
                CheckTypeMatch(targetPropertyType, sourceValueType, "TargetProperty", sourceLabel, filePath, lineNumber);
        }
        catch (Exception ex)
        {
            QLog.Debug(ex);
        }
    }

#if !WINDOWS
    private static FieldInfo FlagsAttachedField = null;
#endif

    private static void CheckPropertyTarget<TBindable>(this TBindable target, DependencyProperty targetProperty, string filePath, int lineNumber) where TBindable : DependencyObject
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

    private static int LastLine([CallerLineNumber] int lineNumber = -1)
        => lineNumber < 0 ? -1 : lineNumber;

    private static bool CheckTypeMatch<TBindable>(Type targetType, TBindable target, DependencyProperty targetProperty, string filePath, int lineNumber) where TBindable : DependencyObject
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
                var properties = targetType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? [];
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
                var fields = targetType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? [];
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

    private static void CheckTypeMatch(Type targetPropertyType, Type sourceType, string targetLabel, string sourceLabel,  string filePath, int lineNumber)
    {
        if (targetPropertyType is null)
            return;

        if (targetPropertyType == typeof(SolidColorBrush) && sourceType == typeof(Brush))
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
    public static TBindable BindX<TBindable>(
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
        object fallbackValue = null, 
        [CallerFilePath] string filePath = null, 
        [CallerLineNumber] int lineNumber = -1
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
    public static TBindable BindX<TBindable, TSource, TDestination>(
        this TBindable target,
        DependencyProperty targetProperty,
        object source = null,
        string path = null,
        BindingMode mode = BindingMode.OneWay,
        Func<TSource, TDestination> convert = null,
        Func<TDestination, TSource> convertBack = null,
        object converterParameter = null,
        string converterLanguage = null,
        UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
        object targetNullValue = null,
        object fallbackValue = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1
    ) where TBindable : DependencyObject
    {
        var converter = new FuncConverter<TSource, TDestination, object>(convert, convertBack, filePath, lineNumber);
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
    public static TBindable BindX<TBindable, TSource, TParam, TDestination>(
        this TBindable target,
        DependencyProperty targetProperty,
        object source = null,
        string path = null,
        BindingMode mode = BindingMode.OneWay,
        Func<TSource, TParam, TDestination> convert = null,
        Func<TDestination, TParam, TSource> convertBack = null,
        object converterParameter = null,
        string converterLanguage = null,
        UpdateSourceTrigger updateSourceTrigger = UpdateSourceTrigger.Default,
        object targetNullValue = null,
        object fallbackValue = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1
    ) where TBindable : DependencyObject
    {
        var converter = new FuncConverter<TSource, TDestination, TParam>(convert, convertBack, filePath, lineNumber);
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

    */
}
