using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using P42.Uno.Extensions.Markup.Generators;
using P42.Uno.Extensions.Markup.Generators.Extensions;
using Uno.Roslyn;

internal static class SharedSymbolExtensions
{
    public static string GetFullyQualifiedTypeIncludingGlobal(this ITypeSymbol type)
    {
        return type.GetFullyQualifiedType(includeGlobalNamespace: true);
    }

    public static string GetFullyQualifiedTypeExcludingGlobal(this ITypeSymbol type)
    {
        return type.GetFullyQualifiedType(includeGlobalNamespace: false);
    }

    private static string GetFullyQualifiedType(this ITypeSymbol type, bool includeGlobalNamespace)
    {
        PooledStringBuilder instance = PooledStringBuilder.GetInstance();
        UnoNamedTypeSymbolDisplayVisitor unoNamedTypeSymbolDisplayVisitor = new UnoNamedTypeSymbolDisplayVisitor(instance.Builder, includeGlobalNamespace);
        type.Accept((SymbolVisitor)(object)unoNamedTypeSymbolDisplayVisitor);
        return instance.ToStringAndFree();
    }

    public static bool IsReferenceTypeOrNullableValueType(this ITypeSymbol type)
    {
        if (!type.IsReferenceType)
            return type.IsNullableValueType();

        return true;
    }

    public static bool IsNullableValueType(this ITypeSymbol type)
    {
        //IL_000e: Unknown result type (might be due to invalid IL or missing references)
        //IL_0015: Invalid comparison between Unknown and I4
        if (type.IsValueType)
            return type.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T;

        return false;
    }

    public static bool IsNullableValueType(this ITypeSymbol type, out ITypeSymbol? underlyingType)
    {
        //IL_000a: Unknown result type (might be due to invalid IL or missing references)
        if (type.IsNullableValueType())
        {
            underlyingType = ((INamedTypeSymbol)type).TypeArguments[0];
            return true;
        }

        underlyingType = null;
        return false;
    }

    public static bool IsInstantiable(this ITypeSymbol type)
    {
        if (!type.IsAbstract)
        {
            if (
                type is INamedTypeSymbol val && 
                val.InstanceConstructors.Any(c => c.DeclaredAccessibility == Accessibility.Public && c.Parameters.IsEmpty)
               )
                return !ForceNotInstantiable(val);

        }
        return false;
    }

    private static bool ForceNotInstantiable(INamedTypeSymbol namedTypeSymbol)
    {
        string name = namedTypeSymbol.Name;
        return name == "UIElement" || name == "ElementStub";
    }

    public static bool IsTypeOrDerivesFromType(this ITypeSymbol? symbol, ITypeSymbol compareSymbol)
    {
        //ITypeSymbol compareSymbol = compareSymbol;
        if (symbol == null)
            return false;

        if (symbol!.AllInterfaces.Any(x => x.Equals(compareSymbol, SymbolEqualityComparer.Default)))
            return true;

        while (symbol != null)
        {
            if (symbol.Equals(compareSymbol, SymbolEqualityComparer.Default))
                return true;

            symbol = symbol.BaseType;
        }

        return false;
    }

    public static bool IsFrameworkTemplate(this INamedTypeSymbol? propertyType, out bool isControlTemplate)
    {
        isControlTemplate = false;
        while (propertyType != null)
        {
            if (
                propertyType.Name == "ControlTemplate" && 
                propertyType.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.Controls.ControlTemplate"
               )
            {
                isControlTemplate = true;
                return true;
            }

            if (
                propertyType.Name == "FrameworkTemplate" && 
                propertyType.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.FrameworkTemplate"
               )
                return true;

            propertyType = propertyType.BaseType;
        }

        return false;
    }

    public static bool IsFrameworkTemplate(this INamedTypeSymbol? propertyType)
    {
        return propertyType.IsFrameworkTemplate(out _);
    }

    public static bool IsDependencyObject(this ITypeSymbol symbol)
    {
        if (symbol.AllInterfaces.Any((INamedTypeSymbol x) => x.Name == "DependencyObject" && ((ITypeSymbol)(object)x).GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.DependencyObject"))
        {
            return true;
        }
        for (ITypeSymbol? val = symbol; val != null; val = val.BaseType)
        {
            if (val.Name == "DependencyObject" && 
                val.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.DependencyObject"
               )
                return true;

        }
        return false;
    }

    public static bool IsResourceDictionary(this ITypeSymbol symbol)
    {
        for (ITypeSymbol? val = symbol; val != null; val = val.BaseType)
        {
            if (val.Name == "ResourceDictionary" && 
                val.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.ResourceDictionary"
               )
                return true;

        }
        return false;
    }

    public static bool IsUIElement(this ITypeSymbol symbol)
    {
        for (ITypeSymbol? val = symbol; val != null; val = val.BaseType)
        {
            if (val.Name == "UIElement" && 
                val.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.UIElement"
               )
                return true;

        }
        return false;
    }

    public static bool IsFrameworkElement(this ITypeSymbol symbol)
    {
        for (ITypeSymbol? val = symbol; val != null; val = val.BaseType)
        {
            if (val.Name == "FrameworkElement" &&
                val.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.FrameworkElement"
                )
                return true;

        }
        return false;
    }
}
