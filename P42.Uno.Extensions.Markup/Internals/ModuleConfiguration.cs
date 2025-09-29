using System;
using System.ComponentModel;
using System.Reflection;
using P42.Uno.Extensions.Markup.Internals;

#nullable enable
namespace P42.Uno.Extensions.Markup.Internals;

[EditorBrowsable(EditorBrowsableState.Never)]
public class ModuleConfiguration
{
    private static readonly string? _entryAssembly = Assembly.GetEntryAssembly()?.GetName().Name;

    public static void Configure(string module, bool isHotReloadEnabled)
    {
        /*
        var value = _entryAssembly is string entryAssembly 
            ? (entryAssembly.Equals(module, StringComparison.OrdinalIgnoreCase) ? 1 : 0) 
            : 0;
        if (value == 0)
            return;
        */

        if (_entryAssembly is not string entryAssembly || !entryAssembly.Equals(module, StringComparison.OrdinalIgnoreCase))
            return;

        Configuration.IsHotReloadEnabled = isHotReloadEnabled;
    }
}
