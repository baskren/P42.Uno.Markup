
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensions;

public static class SymbolExtensions
{
    public static IEnumerable<AttributeData> GetAllAttributes(this ISymbol? symbol)
    { 
        while (symbol != null) 
        //for (; symbol != null; symbol = symbol is INamedTypeSymbol iNamedTypeSymbol ? iNamedTypeSymbol.BaseType : null)
        {
            foreach (var attribute in symbol.GetAttributes())
                yield return attribute;

            symbol = symbol is INamedTypeSymbol iNamedTypeSymbol 
                ? iNamedTypeSymbol.BaseType 
                : null;
        }
    }

    public static IEnumerable<INamedTypeSymbol> GetNamespaceTypes(this INamespaceSymbol sym)
    {
        foreach (var typeMember in sym.GetTypeMembers())
            yield return typeMember;

        foreach (var namespaceMember in sym.GetNamespaceMembers())
        {
            using var enumerator = namespaceMember.GetNamespaceTypes().GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
            //enumerator = (IEnumerator<INamedTypeSymbol>)null;
        }
    }

    public static IEnumerable<INamedTypeSymbol> GetPublicClasses(this INamespaceSymbol sym)
    {
        foreach (var typeMember in sym.GetTypeMembers())
        {
            if (typeMember.DeclaredAccessibility == Accessibility.Public && typeMember.TypeKind == TypeKind.Class)
                yield return typeMember;
        }

        foreach (var namespaceMember in sym.GetNamespaceMembers())
        {
            using var enumerator = namespaceMember.GetPublicClasses().GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.DeclaredAccessibility == Accessibility.Public 
                    && current.TypeKind == TypeKind.Class
                   )
                    yield return current;
            }
            //enumerator = null;
        }
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T obj in collection)
            action(obj);

        return collection;
    }

    public static bool HasPublicSetter(this IPropertySymbol propertySymbol)
        => propertySymbol.SetMethod != null 
            && propertySymbol.SetMethod.DeclaredAccessibility == Accessibility.Public;

    public static bool HasPublicAdder(this IEventSymbol eventSymbol)
        => eventSymbol.AddMethod != null
            && eventSymbol.AddMethod.DeclaredAccessibility == Accessibility.Public;

    public static bool IsCollectionWithAddMethod(this IPropertySymbol propertySymbol)
        => propertySymbol.IsCollection() 
            && HasAddMethod(propertySymbol.Type);
    

    public static bool IsCollection(this IPropertySymbol propertySymbol)
        => ImmutableArrayExtensions.Any
            (
                propertySymbol.Type.AllInterfaces, 
                x => x.Name is "IEnumerable" or "ICollection" or "IList"
            );
    

    private static bool HasAddMethod(ITypeSymbol symbol)
    {
        for (var iTypeSymbol = symbol; iTypeSymbol != null; iTypeSymbol = iTypeSymbol.BaseType)
        {
            if (ImmutableArrayExtensions.Any
                (
                    iTypeSymbol.GetMembers("Add"), 
                    x => x is IMethodSymbol iMethodSymbol 
                        && iMethodSymbol.Parameters.Length == 1
                )
               )
                return true;
        }
        if (symbol.TypeKind == TypeKind.Interface)
        {
            foreach (INamespaceOrTypeSymbol allInterface in symbol.AllInterfaces)
            {
                if (ImmutableArrayExtensions.Any
                    (
                        allInterface.GetMembers("Add"), 
                        x => x is IMethodSymbol iMethodSymbol 
                            && iMethodSymbol.Parameters.Length == 1
                    )
                   )
                    return true;
            }
        }
        return false;
    }

    public static bool IsContentProperty(this IPropertySymbol propertySymbol)
    {
        var attributeData = propertySymbol.ContainingType.GetAllAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "ContentPropertyAttribute");
        if (attributeData == null || attributeData.NamedArguments.Length != 1)
            return false;
        var typedConstant = attributeData.NamedArguments[0].Value;
        return typedConstant.Value is string str && str == propertySymbol.Name;
    }

    public static ImmutableArray<ISymbol> GetSymbolsForGeneration<T>(this INamedTypeSymbol namedType) where T:ISymbol
    {
        var members = namedType.GetMembers();
        var immutableArray = ImmutableArray.ToImmutableArray(members.OfType<T>().Where(property => property.IsShadowing(namedType)));
        var baseType = namedType.BaseType;
        if (baseType != null && baseType.IsGenericType && baseType.IsDependencyObject())
            ProcessGenericType(baseType);
        var hiddenPropertiesWithDifferentTypes = ImmutableHashSet
            .ToImmutableHashSet(
                ImmutableArrayExtensions
                .Where(immutableArray, shadowingProperty => ImmutableArrayExtensions.Any(members, member => member.Name == shadowingProperty.Name && !SymbolEqualityComparer.Default.Equals(member, shadowingProperty))).Select(member => member.Name));
        members = ImmutableArray
            .ToImmutableArray(ImmutableArrayExtensions.Where(members, member => !hiddenPropertiesWithDifferentTypes.Contains(member.Name)));

        return members;

        void ProcessGenericType(INamedTypeSymbol baseNamedType)
        {
            members = ImmutableArray.ToImmutableArray(members.Union(ImmutableArrayExtensions.Where(baseNamedType.GetMembers(), member => !member.IsAbstract), SymbolEqualityComparer.Default));
            var baseType = baseNamedType.BaseType;
            if (baseType == null || !baseType.IsGenericType)
                return;
            ProcessGenericType(baseType);
        }
    }



    private static bool IsShadowing<T>(this T property, INamedTypeSymbol namedType) where T : ISymbol
    {
        for (var baseType = namedType.BaseType; baseType != null; baseType = baseType.BaseType)
        {
            if (baseType.GetMembers(property.Name).OfType<T>().Any())
                return true;
        }
        return false;
    }

    public static bool IsNotImplemented(this ISymbol symbol)
    {
        foreach (var attribute in symbol.GetAttributes())
        {
            if (attribute.AttributeClass?.Name == "NotImplementedAttribute")
            {
                if (attribute.ConstructorArguments.Length == 0)
                    return true;
                TypedConstant constructorArgument = attribute.ConstructorArguments[0];
                ImmutableArray<TypedConstant> values = constructorArgument.Values;
                bool flag1 = false;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                bool flag5 = false;
                foreach (TypedConstant typedConstant in values)
                {
                    if (typedConstant.Value is string str)
                    {
                        switch (str)
                        {
                            case "__ANDROID__":
                                flag1 = true;
                                continue;
                            case "__IOS__":
                                flag2 = true;
                                continue;
                            case "__WASM__":
                                flag3 = true;
                                continue;
                            case "__SKIA__":
                                flag4 = true;
                                continue;
                            case "__MACOS__":
                                flag5 = true;
                                continue;
                            default:
                                continue;
                        }
                    }
                }
                return flag1 & flag2 & flag3 & flag4 & flag5;
            }
        }
        return false;
    }
}
