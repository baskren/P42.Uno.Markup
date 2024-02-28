using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using P42.Utils;
using Windows.Graphics.Display;

namespace P42.Uno.Markup;
internal class WorkaroundBinding : IDisposable
{

    WeakReference<DependencyObject> TargetWeakReference;
    DependencyObject TargetDependencyObject
    {
        get
        {
            if (TargetWeakReference?.TryGetTarget(out DependencyObject target) ?? false)
                return target;
            return null;
        }
        set 
        {
            if (value is null)
                TargetWeakReference = null;
            else
                TargetWeakReference = new WeakReference<DependencyObject>(value);
        }
    }

    WeakReference<object> SourceWeakReference;
    DependencyObject SourceDependencyObject
    {
        get
        {
            if (SourceWeakReference?.TryGetTarget(out object source) ?? false)
                return source as DependencyObject;
            return null;
        }
        set
        {
            if (value is null)
                SourceWeakReference = null;
            else
                SourceWeakReference = new WeakReference<object>(value);
        }
    }

    INotifyPropertyChanged SourceNotifyPropertyChanged
    {
        get
        {
            if (SourceWeakReference?.TryGetTarget(out object source) ?? false)
                return source as INotifyPropertyChanged;
            return null;
        }
        set
        {
            if (value is null)
                SourceWeakReference = null;
            else
                SourceWeakReference = new WeakReference<object>(value);
        }
    }

    internal DependencyProperty TargetProperty;
    Type TargetPropertyType;
    DependencyProperty SourceProperty;
    Type SourcePropertyType;

    string SourcePropertyName;
    PropertyInfo SourcePropertyInfo;

    long OnSourceDependencyPropertyChangedIndex = -1;
    long OnTargetDependencyPropertyChangedIndex = -1;

    IValueConverter ValueConverter;
    object ValueConverterParameter;
    string ValueConverterLanguage = string.Empty;

    private bool disposedValue;

    public WorkaroundBinding(DependencyObject target, DependencyProperty targetProperty, DependencyObject source, DependencyProperty sourceProperty, BindingMode bindingMode, IValueConverter valueConverter, object valueConverterProperty, string valueConverterLanguage)
    {
        if (target is null)
            throw new ArgumentNullException(nameof(target));

        if (targetProperty is null)
            throw new ArgumentException(nameof(targetProperty));

        if (source is null)
            throw new ArgumentException(nameof(source));

        if (sourceProperty is null)
            throw new ArgumentException(nameof(sourceProperty));

        TargetDependencyObject = target;
        TargetProperty = targetProperty;
        if (DependencyPropertyExtensions.DependencyRegistry.TryGetValue(targetProperty, out var targetPropertyEntry))
            TargetPropertyType = targetPropertyEntry.PropertyType;


        SourceDependencyObject = source;
        SourceProperty = sourceProperty;
        if (DependencyPropertyExtensions.DependencyRegistry.TryGetValue(sourceProperty, out var sourcePropertyEntry))
            SourcePropertyType = sourcePropertyEntry.PropertyType;


        switch (bindingMode)
        {
            case BindingMode.OneTime:
                target.SetValue(targetProperty, source.GetValue(sourceProperty));
                break;
            case BindingMode.OneWay:
                OnSourceDependencyPropertyChangedIndex = source.RegisterPropertyChangedCallback(sourceProperty, OnSourceDependencyPropertyChanged);
                break;
            case BindingMode.TwoWay:
                OnSourceDependencyPropertyChangedIndex = source.RegisterPropertyChangedCallback(sourceProperty, OnSourceDependencyPropertyChanged);
                OnTargetDependencyPropertyChangedIndex = target.RegisterPropertyChangedCallback(targetProperty, OnTargetDependencyPropertyChanged);
                break;
        }

        ValueConverter = valueConverter;
        ValueConverterParameter = valueConverterProperty;
        ValueConverterLanguage = valueConverterLanguage;
    }


    public WorkaroundBinding(DependencyObject target, DependencyProperty targetProperty, INotifyPropertyChanged source, string  sourcePropertyName, BindingMode bindingMode, IValueConverter valueConverter, object valueConverterProperty, string valueConverterLanguage) 
    {
        if (target is null)
            throw new ArgumentNullException(nameof(target));

        if (targetProperty is null)
            throw new ArgumentException(nameof(targetProperty));

        if (source is null)
            throw new ArgumentException(nameof(source));

        if (string.IsNullOrWhiteSpace(sourcePropertyName))
            throw new ArgumentException(nameof(sourcePropertyName));

        if (source.GetProperty(sourcePropertyName) is not PropertyInfo sourcePropertyInfo)
            throw new ArgumentException($"Property [{sourcePropertyName}] not found in class [{source}]");

        SourcePropertyInfo = sourcePropertyInfo;

        if (!SourcePropertyInfo.CanRead)
            throw new ArgumentException($"Property [{sourcePropertyName}], in class [{source}], cannot be read.");

        TargetDependencyObject = target;
        TargetProperty = targetProperty;
        if (DependencyPropertyExtensions.DependencyRegistry.TryGetValue(targetProperty, out var targetPropertyEntry))
            TargetPropertyType = targetPropertyEntry.PropertyType;

        SourceNotifyPropertyChanged = source;
        SourcePropertyName = sourcePropertyName;
        SourcePropertyType = sourcePropertyInfo.PropertyType;

        switch (bindingMode)
        {
            case BindingMode.OneTime:
                target.SetValue(targetProperty, source.GetPropertyValue(sourcePropertyName));
                break;
            case BindingMode.OneWay:
                source.PropertyChanged += OnSourceNotifyPropertyChanged;
                break;
            case BindingMode.TwoWay:

                if (!SourcePropertyInfo.CanWrite)
                    throw new ArgumentException($"Property [{sourcePropertyName}], in class [{source}], cannot be written to.");

                source.PropertyChanged += OnSourceNotifyPropertyChanged;
                OnTargetDependencyPropertyChangedIndex = target.RegisterPropertyChangedCallback(targetProperty, OnTargetDependencyPropertyChanged);
                break;
        }

        ValueConverter = valueConverter;
        ValueConverterParameter = valueConverterProperty;
        ValueConverterLanguage = valueConverterLanguage;
    }

    private void OnTargetDependencyPropertyChanged(DependencyObject sender, DependencyProperty dp)
    {
        if (TargetDependencyObject is not DependencyObject target)
            return;

        var value = target.GetValue(TargetProperty);

        if (ValueConverter is IValueConverter converter)
            value = converter.ConvertBack(value, SourcePropertyType, ValueConverterParameter, ValueConverterLanguage);

        SourceDependencyObject?.SetValue(SourceProperty, value);

        if (SourceNotifyPropertyChanged is not INotifyPropertyChanged source)
            return;
        SourcePropertyInfo?.SetValue(source, value);
    }

    private void OnSourceDependencyPropertyChanged(DependencyObject sender, DependencyProperty dp)
    {
        if (SourceDependencyObject is not DependencyObject source)
            return;
        var value = source.GetValue(SourceProperty);
        if (ValueConverter is IValueConverter converter)
            value = converter.Convert(value, TargetPropertyType, ValueConverterParameter, ValueConverterLanguage);


        TargetDependencyObject?.SetValue(TargetProperty, value);
    }

    private void OnSourceNotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == SourcePropertyName)
        {
            if (SourceNotifyPropertyChanged is not INotifyPropertyChanged source)
                return;

            var value = SourcePropertyInfo.GetValue(source, null);
            TargetDependencyObject.SetValue(TargetProperty, value);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (OnSourceDependencyPropertyChangedIndex > -1)
                    SourceDependencyObject?.UnregisterPropertyChangedCallback(SourceProperty, OnSourceDependencyPropertyChangedIndex);
                if (OnTargetDependencyPropertyChangedIndex > -1) 
                    TargetDependencyObject?.UnregisterPropertyChangedCallback(TargetProperty, OnTargetDependencyPropertyChangedIndex);

                if (SourceNotifyPropertyChanged is INotifyPropertyChanged source)
                    source.PropertyChanged -= OnSourceNotifyPropertyChanged;

                SourceWeakReference = null;
                TargetWeakReference = null;
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~WorkaroundBinding()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

internal enum WorkaroundBindingSourceType
{
    Value,
    DependencyProperty,
    INotifyPropertyChanged,
}
