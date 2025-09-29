using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using P42.Uno.Extensions.Markup.Generators;
using P42.Uno.Extensions.Markup.Generators.Extensions;

namespace P42.Uno.Extensions.Markup.Generators;

[Generator("C#", [])]
internal sealed class EventExtensionGenerator : IncrementalExtensionsGeneratorBase<EventExtensionInfo>
{

    private protected override void GenerateCodeFromInfosCore(
        ClassBuilder builder, 
        EquatableArray<EventExtensionInfo> infos, 
        SourceProductionContext context, 
        CancellationToken cancellationToken)
    {
        foreach (var info in infos)
        {
            cancellationToken.ThrowIfCancellationRequested();
            GeneratorEventExtensions(builder, info);
        }
        infos.FirstOrDefault();
    }

    private protected override string GetClassName(string typeName) => typeName + "Markup";

    private protected override EquatableArray<EventExtensionInfo>? GetInfoForType(INamedTypeSymbol namedType)
    {
        if (!namedType.IsDependencyObject() || namedType.IsGenericType)
            return new EquatableArray<EventExtensionInfo>?();

        if (namedType.Name is "Binding" or "Setter")
            return new EquatableArray<EventExtensionInfo>?();

        var generationTypeIsFrameworkElement = namedType.IsFrameworkTemplate();
        for (var type = namedType; type != null; type = type.BaseType)
        {
            if (type.Name == "FrameworkElement" && type.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.FrameworkElement")
            {
                generationTypeIsFrameworkElement = true;
                break;
            }
        }

        var membersForGeneration = namedType.GetSymbolsForGeneration<IEventSymbol>();
        var iEventSymbols = membersForGeneration
            .OfType<IEventSymbol>()
            .Where(x => x.HasPublicAdder());
        var builder = ImmutableArray.CreateBuilder<EventExtensionInfo>();
        var typeInfo = GenerationTypeInfo.From(namedType);

        foreach (IEventSymbol @event in iEventSymbols)
        {
            if (
                !@event.IsStatic
                && !@event.Name.Contains(".")
                && @event.DeclaredAccessibility != Accessibility.Private
                && @event.DeclaredAccessibility != Accessibility.Protected
                && !@event.IsNotImplemented()
               )
            {
                builder.Add(EventExtensionInfo.From(
                        @event,
                        typeInfo,
                        !namedType.IsSealed && IsShadowing(@event, namedType)
                    ));
            }
        }

        return new EquatableArray<EventExtensionInfo>?(builder.ToImmutable().AsEquatableArray());
    }

    private static bool IsShadowing(IEventSymbol property, INamedTypeSymbol namedType)
    {
        var iNamedTypeSymbol = namedType;
        while (iNamedTypeSymbol != null && !(iNamedTypeSymbol.Name == "UIElement"))
        {
            iNamedTypeSymbol = iNamedTypeSymbol.BaseType;
            if (iNamedTypeSymbol != null && iNamedTypeSymbol.GetMembers(property.Name).Length > 0)
                return true;
        }
        return false;
    }

    private static string AdjustParameterName(string parameterName)
    => parameterName == "element"
        ? "value"
        : parameterName.EscapeIdentifier();


    private void GeneratorEventExtensions(ClassBuilder classBuilder, EventExtensionInfo info)
    {
        var returnTypeName = info.EventTypeFullyQualified;

        if (info.EventHasPublicAdder)
        {
            var parameterName = $"on{info.EventName}Handler"; // AdjustParameterName(info.EventName.Camelcase());
            var methodBuilder = CreateEventBuilder(ref classBuilder, info.GenerationTypeInfo, info.EventName, info.IsNotSealedAndIsShadowing)
                    .AddParameter(returnTypeName, parameterName)
                    .WithBody(w =>
                    {
                        w.AppendLine($"element.{info.EventName} += {parameterName};");
                        w.AppendLine("return element;");
                    });
        }
    }

    private static MethodBuilder CreateEventBuilder(
            ref ClassBuilder classBuilder,
            GenerationTypeInfo generationTypeInfo,
            string eventName,
            bool forceStronglyTyped = false)
    {
        var parameterized = classBuilder
            .AddMethod($"Add{eventName}Handler")
            .MakePublicMethod()
            .MakeStaticMethod()
            .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute");

        if (generationTypeInfo.IsSealed | forceStronglyTyped)
            parameterized.
                AddParameter("this " + generationTypeInfo.TypeFullyQualifiedName, "element")
                .WithReturnType(generationTypeInfo.TypeFullyQualifiedName);
        else
            parameterized
                .AddGeneric("T", _ => _.AddConstraint(generationTypeInfo.TypeFullyQualifiedName))
                .AddParameter("this T", "element").WithReturnType("T");

        return parameterized;

    }
}
