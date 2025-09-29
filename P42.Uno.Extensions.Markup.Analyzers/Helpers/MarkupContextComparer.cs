using System;
using System.Collections.Generic;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers.Helpers;

internal sealed class MarkupContextComparer : EqualityComparer<MarkupViewContext?>
{
    public static readonly MarkupContextComparer Instance = new();

    private MarkupContextComparer()
    {
    }

    public override bool Equals(MarkupViewContext? x, MarkupViewContext? y)
    {
        StringComparer ordinal = StringComparer.Ordinal;
        MarkupViewContext valueOrDefault;
        string? x1;
        if (!x.HasValue)
            x1 = null;
        else
        {
            valueOrDefault = x.GetValueOrDefault();
            x1 = valueOrDefault.QualifiedTypeName;
        }

        string? y1;
        if (!y.HasValue)
            y1 = null;
        else
        {
            valueOrDefault = y.GetValueOrDefault();
            y1 = valueOrDefault.QualifiedTypeName;
        }

        return ordinal.Equals(x1, y1);
    }

    public override int GetHashCode(MarkupViewContext? obj)
        => StringComparer.Ordinal.GetHashCode(obj);
    
}
