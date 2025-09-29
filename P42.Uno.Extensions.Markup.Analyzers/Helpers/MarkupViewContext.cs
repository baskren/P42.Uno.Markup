using Microsoft.CodeAnalysis;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers.Helpers;

internal struct MarkupViewContext
{
    public MarkupViewContext(INamedTypeSymbol symbol)
    {
        Name = symbol.Name;
        Namespace = symbol.ContainingNamespace.ToDisplayString(null);
        QualifiedTypeName = ((ITypeSymbol)symbol).GetFullyQualifiedTypeExcludingGlobal();
        IsUIElement = ((ITypeSymbol)symbol).IsUIElement();
    }

    public string Name { get; }

    public string Namespace { get; }

    public string QualifiedTypeName { get; }

    public bool IsUIElement { get; }
}
