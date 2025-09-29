using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

internal record struct GenerationTypeInfo(
  string TypeFullyQualifiedName,
  string TypeName,
  string TypeContainingNamespace,
  Accessibility DeclaredAccessibility,
  bool IsSealed)
{
    public static GenerationTypeInfo From(INamedTypeSymbol typeSymbol)
        => new(
            typeSymbol.GetFullyQualifiedTypeIncludingGlobal(), 
            typeSymbol.Name, 
            typeSymbol.ContainingNamespace.ToDisplayString(null), 
            typeSymbol.DeclaredAccessibility, 
            typeSymbol.IsSealed);
    
}
