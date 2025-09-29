using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable enable
namespace P42.Uno.Extensions.Markup.Delegators;

[Microsoft.UI.Xaml.Data.Bindable]
[EditorBrowsable(EditorBrowsableState.Never)]
public class BuildChild
{
    public static readonly DependencyProperty IdProperty = DependencyProperty.RegisterAttached("Id", typeof(string), typeof(BuildChild), new PropertyMetadata(null, new PropertyChangedCallback(BuildChild.OnIdChanged)));

    internal static Dictionary<string, Func<UIElement>>? Delegates { get; private set; } = null;

    private static string Id(Delegate build)
    {
        var interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
        interpolatedStringHandler.AppendFormatted(build.Method.DeclaringType?.FullName);
        interpolatedStringHandler.AppendLiteral(".");
        interpolatedStringHandler.AppendFormatted(build.Method.Name);
        interpolatedStringHandler.AppendLiteral(".");
        ref DefaultInterpolatedStringHandler local = ref interpolatedStringHandler;
        int hashCode = build.Target != null ? build.Target.GetHashCode() : 0;
        local.AppendFormatted(hashCode);
        return interpolatedStringHandler.ToStringAndClear();
    }

    public static string CreateIdFor(Func<UIElement> build)
    {
        Delegates ??= [];
        string key = Id(build);
        Delegates[key] = build;
        return key;
    }

    public static string GetId(Panel panel)
        => (string)panel.GetValue(IdProperty);
    

    public static void SetId(Panel panel, string id)
        => panel.SetValue(IdProperty, id);
    

    private static void OnIdChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        => Build((Panel)target, (string)e.NewValue);
    

    private static void Build(Panel panel, string? id = null)
    {
        if (id == null || string.IsNullOrEmpty(id) || Delegates == null)
            return;
        
        panel.Children.Clear();
        panel.Children.Add(Delegates[id]());
    }
}
