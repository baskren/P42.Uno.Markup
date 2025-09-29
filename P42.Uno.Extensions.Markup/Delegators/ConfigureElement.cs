using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable enable
namespace Uno.Extensions.Markup.Delegators;

[Microsoft.UI.Xaml.Data.Bindable]
[EditorBrowsable(EditorBrowsableState.Never)]
public class ConfigureElement
{
    public static readonly DependencyProperty IdProperty = DependencyProperty
        .RegisterAttached(
            "Id", typeof(string), 
            typeof(ConfigureElement), 
            new PropertyMetadata(null, new PropertyChangedCallback(OnIdChanged))
        );

    internal static Dictionary<string, Action<UIElement>>? Delegates { get; private set; } = null;

    private static string Id(Action<UIElement> configure)
    {
        return $"{configure.Method.DeclaringType?.FullName}.{configure.Method.Name}";
    }

    public static string? CreateIdFor(Action<UIElement>? configure)
    {
        Delegates ??= [];

        if (configure == null)
            return null;

        string key = Id(configure);
        Delegates[key] = configure;
        return key;
    }

    public static string GetId(UIElement element)
        => (string)element.GetValue(IdProperty);
    

    public static void SetId(UIElement element, string id)
        => element.SetValue(IdProperty, id);
    

    private static void OnIdChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        => Configure((UIElement)target, (string)e.NewValue);
    

    private static void Configure(UIElement element, string? id = null)
    {
        if (id == null || string.IsNullOrEmpty(id) || Delegates == null)
            return;

        Delegates[id](element);
    }
}
