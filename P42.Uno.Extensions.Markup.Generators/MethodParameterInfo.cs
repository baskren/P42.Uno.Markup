using Microsoft.CodeAnalysis;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

internal record struct MethodParameterInfo(
  string ParameterTypeFullyQualified,
  bool IsReferenceTypeOrNullableValueType,
  bool IsTextElement,
  bool IsDependencyObject)
{
    public static MethodParameterInfo From(ITypeSymbol type)
    {
        bool IsTextElement = false;
        for (var type1 = type; type1 != null; type1 = type1.BaseType)
        {
            if (type1.Name == "TextElement" 
                && type1.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.Documents.TextElement")
            {
                IsTextElement = true;
                break;
            }
        }
        return new MethodParameterInfo(
            type.GetFullyQualifiedTypeIncludingGlobal(), 
            type.IsReferenceTypeOrNullableValueType(), 
            IsTextElement, 
            type.IsDependencyObject());
    }
}
