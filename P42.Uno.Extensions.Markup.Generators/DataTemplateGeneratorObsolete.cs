using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

[Generator("C#", [])]
internal sealed class DataTemplateGeneratorObsolete : IncrementalExtensionsGeneratorBase<DataTemplateInfo>
{
    private protected override EquatableArray<DataTemplateInfo>? GetInfoForType(INamedTypeSymbol namedType)
    {
        return null;

        if (namedType.IsGenericType)
            return new EquatableArray<DataTemplateInfo>?();

        var builder = ImmutableArray.CreateBuilder<DataTemplateInfo>();

        var GenerationTypeInfo =Generators.GenerationTypeInfo.From(namedType);
        foreach (var iPropertySymbol in namedType.GetMembers().OfType<IPropertySymbol>())
        {
            if (!iPropertySymbol.IsStatic && !iPropertySymbol.IsReadOnly)
            {
                string typeExcludingGlobal = iPropertySymbol.Type.GetFullyQualifiedTypeExcludingGlobal();
                string PropertyTypeFullyQualifiedName = "global::" + typeExcludingGlobal;
                if ((!(iPropertySymbol.Type.Name == "DataTemplateSelector") ? 0 : (typeExcludingGlobal == "Microsoft.UI.Xaml.Controls.DataTemplateSelector" ? 1 : 0)) != 0)
                {
                    builder.Add(new DataTemplateInfo(PropertyTypeFullyQualifiedName, false, false, true, false, iPropertySymbol.Name, iPropertySymbol.Type.Name, GenerationTypeInfo));
                }
                else
                {
                    if (iPropertySymbol.SetMethod != null && (iPropertySymbol.Type as INamedTypeSymbol).IsFrameworkTemplate(out bool isControlTemplate))
                    {
                        bool PropertyTypeIsDataTemplate = iPropertySymbol.Type.Name == "DataTemplate" && typeExcludingGlobal == "Microsoft.UI.Xaml.DataTemplate";
                        builder.Add(new DataTemplateInfo(PropertyTypeFullyQualifiedName, isControlTemplate, PropertyTypeIsDataTemplate, false, false, iPropertySymbol.Name, iPropertySymbol.Type.Name, GenerationTypeInfo));
                    }
                }
            }
        }
        var baseType = namedType.BaseType;
        while (baseType != null)
        {
            foreach (var iPropertySymbol in baseType.GetMembers().OfType<IPropertySymbol>())
            {
                var property = iPropertySymbol;
                if (!builder.Any(x => x.PropertyName == property.Name))
                {
                    string typeExcludingGlobal = property.Type.GetFullyQualifiedTypeExcludingGlobal();
                    if ((property.Type as INamedTypeSymbol).IsFrameworkTemplate(out bool isControlTemplate))
                    {
                        bool flag = property.Type.Name == "DataTemplate" && typeExcludingGlobal == "Microsoft.UI.Xaml.DataTemplate";
                        string PropertyTypeFullyQualifiedName = "global::" + typeExcludingGlobal;
                        builder.Add(new DataTemplateInfo(
                            PropertyTypeFullyQualifiedName, 
                            isControlTemplate, 
                            flag, 
                            false, 
                            flag, 
                            property.Name, 
                            property.Type.Name, 
                            GenerationTypeInfo));
                    }
                }
            }
            baseType = baseType.BaseType;
            if (baseType == null || baseType.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.UIElement")
                break;
        }
        return builder.Count == 0 
            ? new EquatableArray<DataTemplateInfo>?() 
            : new EquatableArray<DataTemplateInfo>?(builder.ToImmutableArray().AsEquatableArray());
    }

    private protected override string GetClassName(string typeName) => typeName + "Markup";

    private protected override void GenerateCodeFromInfosCore(
      ClassBuilder classBuilder,
      EquatableArray<DataTemplateInfo> infos,
      SourceProductionContext context,
      CancellationToken cancellationToken)
    {
        foreach (var info1 in infos)
        {
            var info = info1;
            cancellationToken.ThrowIfCancellationRequested();
            GenerationTypeInfo generationTypeInfo;
            if (info.PropertyTypeIsDataTemplateSelector)
            {
                var methodBuilder = classBuilder
                    .AddMethod(info.PropertyName)
                    .MakePublicMethod()
                    .MakeStaticMethod()
                    .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute");
                generationTypeInfo = info.GenerationTypeInfo;
                string fullyQualifiedName = generationTypeInfo.TypeFullyQualifiedName;
                var parameterized = methodBuilder
                    .WithReturnType(fullyQualifiedName)
                    .AddGeneric("TItem");
                generationTypeInfo = info.GenerationTypeInfo;
                string typeName = "this " + generationTypeInfo.TypeFullyQualifiedName;
                parameterized
                    .AddParameter(typeName, "element")
                    .AddParameter("Action<TItem, MarkupDataTemplateSelectorBuilder<TItem>>", "configureDataTemplateSelector")
                    .WithBody(w =>
                    {
                        w.AppendLine("var builder = new MarkupDataTemplateSelectorBuilder<TItem>();");
                        w.AppendUnindentedLine("#nullable disable");
                        w.AppendLine("configureDataTemplateSelector(default, builder);");
                        w.AppendUnindentedLine("#nullable enable");
                        w.AppendLine($"element.{info.PropertyName} = builder;");
                        w.AppendLine("return element;");
                    });
            }
            else
            {
                string delegateName = info.PropertyTypeName.Camelcase() + "Delegate";
                if (info.PropertyTypeIsControlTemplate)
                {
                    
                    var methodBuilder = classBuilder
                        .AddMethod(info.PropertyName)
                        .MakePublicMethod()
                        .MakeStaticMethod()
                        .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute");
                    var controlType = "TControl";
                    if (!info.GenerationTypeInfo.IsSealed)
                    {
                        methodBuilder
                            .AddGeneric("TControl", b => b.AddConstraint(info.GenerationTypeInfo.TypeFullyQualifiedName))
                            .WithReturnType("TControl")
                            .AddParameter("this TControl", "element");
                    }
                    else
                    {
                        controlType = info.GenerationTypeInfo.TypeFullyQualifiedName;
                        methodBuilder
                            .WithReturnType(info.GenerationTypeInfo.TypeFullyQualifiedName)
                            .AddParameter("this " + info.GenerationTypeInfo.TypeFullyQualifiedName, "element");
                    }
                    if (info.PropertyTypeName == "ControlTemplate")
                        methodBuilder
                            .AddParameter("Func<UIElement>", delegateName)
                            .WithBody(w =>
                            {
                                w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.ControlTemplate(() => {delegateName}(), typeof({controlType}));");
                                w.AppendLine("return element;");
                            });
                    else
                        methodBuilder
                            .AddGeneric("TRootControl", b => b.AddConstraint("UIElement"))
                            .AddParameter($"Func<{controlType}, TRootControl>", delegateName)
                            .WithBody(w =>
                            {
                                w.AppendUnindentedLine("#nullable disable");
                                w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.FrameworkTemplate<{info.PropertyTypeFullyQualifiedName}>(() => (UIElement){delegateName}(element), typeof({controlType}));");
                                w.AppendUnindentedLine("#nullable enable");
                                w.AppendLine("return element;");
                            });
                    
                }
                else if (!info.PropertyTypeIsDataTemplate)
                {
                    
                    var methodBuilder = classBuilder
                        .AddMethod(info.PropertyName)
                        .MakePublicMethod()
                        .MakeStaticMethod()
                        .WithReturnType(info.GenerationTypeInfo.TypeFullyQualifiedName)
                        .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute")
                        .AddParameter("this " + info.GenerationTypeInfo.TypeFullyQualifiedName, "element");
                    if (info.PropertyTypeName == "ItemsPanelTemplate")
                        methodBuilder
                            .AddGeneric("TItem", b => b.AddConstraint("UIElement, new()"))
                            .AddParameterWithNullValue("Action<TItem>?", "configureItemsPanel")
                            .WithBody(w =>
                            {
                                w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.ItemsPanelTemplate<TItem>(configureItemsPanel);");
                                w.AppendLine("return element;");
                            });
                    else
                        methodBuilder
                            .AddParameter("Func<UIElement>", delegateName)
                            .WithBody(w =>
                            {
                                if (info.PropertyTypeName == "FrameworkTemplate")
                                    w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.FrameworkTemplate(() => {delegateName}());");
                                else
                                    w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.FrameworkTemplate<{info.PropertyTypeFullyQualifiedName}>({delegateName});");
                                w.AppendLine("return element;");
                            });
                    
                }
                else
                {
                    
                    classBuilder
                        .AddMethod(info.PropertyName)
                        .MakePublicMethod()
                        .MakeStaticMethod()
                        .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute")
                        .WithReturnType(info.GenerationTypeInfo.TypeFullyQualifiedName)
                        .AddGeneric("TItem")
                        .AddParameter("this " + info.GenerationTypeInfo.TypeFullyQualifiedName, "element")
                        .AddParameter("Func<TItem, UIElement>", delegateName)
                        .WithBody(w =>
                        {
                            w.AppendUnindentedLine("#nullable disable");
                            if (info.PropertyTypeIsDataTemplate)
                                w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.DataTemplate(() => {delegateName}(default));");
                            else
                                w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.FrameworkTemplate<{info.PropertyTypeFullyQualifiedName}>(() => {delegateName}(default));");
                            w.AppendUnindentedLine("#nullable enable");
                            w.AppendLine("return element;");
                        });
                    classBuilder
                        .AddMethod(info.PropertyName)
                        .MakePublicMethod()
                        .MakeStaticMethod()
                        .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute")
                        .WithReturnType(info.GenerationTypeInfo.TypeFullyQualifiedName)
                        .AddParameter("this " + info.GenerationTypeInfo.TypeFullyQualifiedName, "element")
                        .AddParameter("Func<UIElement>", delegateName)
                        .WithBody(w =>
                        {
                            w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.DataTemplate(() => {delegateName}());");
                            w.AppendLine("return element;");
                        });
                    classBuilder
                        .AddMethod(info.PropertyName)
                        .MakePublicMethod()
                        .MakeStaticMethod()
                        .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute")
                        .WithReturnType(info.GenerationTypeInfo.TypeFullyQualifiedName)
                        .AddGeneric("TItem")
                        .AddGeneric("TRoot", b => b.AddConstraint("UIElement, new()"))
                        .AddParameter("this " + info.GenerationTypeInfo.TypeFullyQualifiedName, "element")
                        .AddParameter("Action<TItem, TRoot>", "configureRoot")
                        .WithBody(w =>
                        {
                            w.AppendUnindentedLine("#nullable disable");
                            w.AppendLine($"element.{info.PropertyName} = DataTemplateHelpers.DataTemplate<TRoot>(root => configureRoot(default, root));");
                            w.AppendUnindentedLine("#nullable enable");
                            w.AppendLine("return element;");
                        });
                    
                }
            }
        }
    }

    private static MethodBuilder CreatePropertyBuilder(
          ref ClassBuilder classBuilder,
          GenerationTypeInfo generationTypeInfo,
          string propertyName,
          bool forceStronglyTyped = false
        )
    {
        var parameterized = classBuilder
            .AddMethod(propertyName)
            .MakePublicMethod()
            .MakeStaticMethod()
            .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute");

        if (generationTypeInfo.IsSealed | forceStronglyTyped)
            parameterized
                .AddParameter("this " + generationTypeInfo.TypeFullyQualifiedName, "element")
                .WithReturnType(generationTypeInfo.TypeFullyQualifiedName);
        else
            parameterized
                .AddGeneric("T", _ => _.AddConstraint(generationTypeInfo.TypeFullyQualifiedName))
                .AddParameter("this T", "element")
                .WithReturnType("T");

        return parameterized;
    }

}
