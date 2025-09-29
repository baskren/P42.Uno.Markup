using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using P42.Uno.Extensions.Markup.Generators.Extensibility;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

[Generator("C#", [])]
internal sealed class StyleBuilderGenerator : IncrementalExtensionsGeneratorBase<StyleBuilderInfo>
{
    private protected override void GenerateCodeFromInfosCore(
      ClassBuilder builder,
      EquatableArray<StyleBuilderInfo> infos,
      SourceProductionContext context,
      CancellationToken cancellationToken)
    {
        //return;

        foreach (StyleBuilderInfo info in infos)
        {
            cancellationToken.ThrowIfCancellationRequested();
            GenerateStyleBuilderExtensions(builder, info);
        }
    }

    private protected override EquatableArray<StyleBuilderInfo>? GetInfoForType(
      INamedTypeSymbol namedType)
    {
        return null;

        if (namedType.IsGenericType)
            return new EquatableArray<StyleBuilderInfo>?();

        var type = namedType;
        bool flag = false;
        for (; type != null; type = type.BaseType)
        {
            if (type.Name == "UIElement" && type.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.UIElement")
            {
                flag = true;
                break;
            }
        }
        if (!flag)
            return new EquatableArray<StyleBuilderInfo>?();

        var builder = ImmutableArray.CreateBuilder<StyleBuilderInfo>();
        var typeInfo = GenerationTypeInfo.From(namedType);
        var membersForGeneration = namedType.GetSymbolsForGeneration<IPropertySymbol>();
        foreach (var iPropertySymbol in membersForGeneration.OfType<IPropertySymbol>())
        {
            IPropertySymbol property = iPropertySymbol;
            if (
                !property.IsStatic 
                && property.DeclaredAccessibility == Accessibility.Public 
                && !(property.Name == "TemplatedParent") 
                && !property.IsNotImplemented() 
                && ImmutableArrayExtensions.Any(membersForGeneration, m => m.Name == property.Name + "Property")
               )
                builder.Add(StyleBuilderInfo.From(property, typeInfo));
        }
        return new EquatableArray<StyleBuilderInfo>?(builder.ToImmutableArray().AsEquatableArray());
    }

    private protected override string GetClassName(string typeName) => typeName + "StyleMarkup";

    private static void GenerateStyleBuilderExtensions(ClassBuilder builder, StyleBuilderInfo info)
    {
        if (builder.Methods.Any(x => x.Name == info.PropertyName))
            return;
        string containingType = info.PropertyContainingTypeFullyQualified;
        string qualifiedTypeName = info.PropertyTypeFullyQualified;
        string propName = info.PropertyName.Camelcase();
        string dpName = $"{containingType}.{info.PropertyName}Property";
        string propPath = $"\"{info.PropertyName}\"";

        /*
        CreateBuilder(builder, info.GenerationTypeInfo, info.PropertyName).AddParameter<MethodBuilder>(qualifiedTypeName, propName).WithBody(w =>
        {
            if (info.IsNullableValueType)
                w.If(propName + ".HasValue").WithBody(x => x.AppendLine($"builder.Add({dpName}, {propPath}, {propName}.Value);")).EndIf();
            else
                w.AppendLine($"builder.Add({dpName}, {propPath}, {propName});");
            w.AppendLine("return builder;");
        });
         CreateBuilder(builder, info.GenerationTypeInfo, info.PropertyName).AddParameter<MethodBuilder>($"Action<IDependencyPropertyBuilder<{qualifiedTypeName}>>", "configureProperty").WithBody(w => w.AppendLine($"return builder.Add({dpName}, \"{info.PropertyName}\", {propPath}, configureProperty);"));
        */

        ExtensibilityLocator.Extensions.ForEach(x =>
        {
            if (!x.CanExtend(qualifiedTypeName))
                return;
            x.WriteStyleBuilderExtensions(builder, info, (methodName) => CreateBuilder(builder, info.GenerationTypeInfo, methodName));
        });

        /*
        if (qualifiedTypeName == "global::Microsoft.UI.Xaml.Controls.ControlTemplate")
        {
            GenerateControlTemplateExtensions(builder, info);
        }
        else
        {
            if (!info.PropertyTypeIsOrDerivesFromFrameworkTemplate)
                return;
            GenerateFrameworkTemplateStyleBuilderExtensions(builder, info);
        }
        */
    }

    private static void GenerateControlTemplateExtensions(ClassBuilder builder, StyleBuilderInfo info)
    {
        string qualifiedTypeName = info.GenerationTypeInfo.TypeFullyQualifiedName;
        string delegateName = info.PropertyTypeName.Camelcase() + "Delegate";
        string typeFullyQualified = info.PropertyTypeFullyQualified;
        string styleBuilderTypeParameter = info.GenerationTypeInfo.IsSealed ? qualifiedTypeName : "T";
        string returnType = $"StyleBuilder<{styleBuilderTypeParameter}>";
        MethodBuilder methodBuilder = builder.AddMethod(info.PropertyName).MakePublicMethod().MakeStaticMethod().WithReturnType(returnType).AddGeneric("TRootControl", b => b.AddConstraint("UIElement")).AddParameter("this " + returnType, nameof(builder)).AddParameter($"Func<{styleBuilderTypeParameter}, TRootControl>", delegateName).WithBody(w =>
        {
            w.AppendUnindentedLine("#nullable disable");
            w.AppendLine($"var template = DataTemplateHelpers.ControlTemplate(() => (UIElement){delegateName}(default), typeof({styleBuilderTypeParameter}));");
            w.AppendLine($"builder.Add({info.PropertyContainingTypeFullyQualified}.{info.PropertyName}Property, template);");
            w.AppendUnindentedLine("#nullable enable");
            w.AppendLine("return builder;");
        });
        if (info.GenerationTypeInfo.IsSealed)
            return;
        methodBuilder.AddGeneric("T", b => b.AddConstraint(qualifiedTypeName));
    }

    private static void GenerateFrameworkTemplateStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info)
    {
        string propTypeName = info.PropertyTypeName.Camelcase();
        string propName = propTypeName + "Delegate";
        string methodName = info.PropertyTypeIsOrDerivesFromDataTemplate ? "DataTemplate" : $"FrameworkTemplate<{info.PropertyTypeFullyQualified}>";
        string qualifiedTypeName = info.GenerationTypeInfo.TypeFullyQualifiedName;
        GenerationTypeInfo generationTypeInfo = info.GenerationTypeInfo;
        string returnType = generationTypeInfo.IsSealed ? $"StyleBuilder<{qualifiedTypeName}>" : "StyleBuilder<TElement>";
        MethodBuilder methodBuilder = builder.AddMethod(info.PropertyName).MakePublicMethod().MakeStaticMethod().WithReturnType(returnType).AddGeneric("T").AddParameter("this " + returnType, nameof(builder)).AddParameter("Func<T, UIElement>", propName).WithBody(w =>
        {
            w.AppendUnindentedLine("#nullable disable");
            w.AppendLine($"var {propTypeName} = DataTemplateHelpers.{methodName}(() => {propName}(default));");
            w.AppendLine($"builder.Add({info.PropertyContainingTypeFullyQualified}.{info.PropertyName}Property, {propTypeName});");
            w.AppendUnindentedLine("#nullable enable");
            w.AppendLine("return builder;");
        });
        generationTypeInfo = info.GenerationTypeInfo;
        if (generationTypeInfo.IsSealed)
            return;
        methodBuilder.AddGeneric("TElement", b => b.AddConstraint(qualifiedTypeName));
    }

    private static MethodBuilder CreateBuilder(
      ClassBuilder builder,
      GenerationTypeInfo generationTypeInfo,
      string propertyName)
    {
        string typeName = generationTypeInfo.TypeFullyQualifiedName;
        string returnType = generationTypeInfo.IsSealed ? $"StyleBuilder<{typeName}>" : "StyleBuilder<T>";
        MethodBuilder builder1 = builder
            .AddMethod(propertyName)
            .MakePublicMethod()
            .MakeStaticMethod()
            .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute")
            .WithReturnType(returnType)
            .AddParameter("this " + returnType, nameof(builder));
        if (!generationTypeInfo.IsSealed)
            builder1.AddGeneric("T", b => b.AddConstraint(typeName));
        return builder1;
    }
    
}
