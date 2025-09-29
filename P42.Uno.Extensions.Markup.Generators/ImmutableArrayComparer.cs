using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

internal sealed class ImmutableArrayComparer : IEqualityComparer<ImmutableArray<IAssemblySymbol>>
{
    public static IEqualityComparer<ImmutableArray<IAssemblySymbol>> Instance { get; } = (IEqualityComparer<ImmutableArray<IAssemblySymbol>>)new ImmutableArrayComparer();

    private ImmutableArrayComparer()
    {
    }

    public bool Equals(ImmutableArray<IAssemblySymbol> x, ImmutableArray<IAssemblySymbol> y)
    {
        if (x.Length != y.Length)
            return false;
        for (int index = 0; index < x.Length; ++index)
        {
            if (!x[index].Equals(y[index], SymbolEqualityComparer.Default))
                return false;
        }
        return true;
    }

    public int GetHashCode(ImmutableArray<IAssemblySymbol> obj)
    {
        HashCode hashCode = new();
        foreach (IAssemblySymbol iAssemblySymbol in obj)
            hashCode.Add(iAssemblySymbol);
        return hashCode.ToHashCode();
    }
}
