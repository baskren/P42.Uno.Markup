using Microsoft.CodeAnalysis.Diagnostics;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers.Helpers;

internal static class AnalyzerOptionsExtensions
{
    public static string? GetMSBuildPropertyValue(this AnalyzerOptions options, string optionName)
        => options.AnalyzerConfigOptionsProvider.GlobalOptions.TryGetValue("build_property." + optionName, out var str) 
            ? str 
            : null;
    
}
