// Decompiled with JetBrains decompiler
// Type: Uno.Extensions.Markup.Generators.DataTemplateGenerator
// Assembly: Uno.Extensions.Markup.Generators, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null
// MVID: E6210F11-717B-4BCF-8EB9-4DC107A6F4FB
// Assembly location: C:\Users\ben\AppData\Local\Temp\Zehykin\f1db9ce6ec\analyzers\dotnet\cs\Uno.Extensions.Markup.Generators.dll

using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

[Generator("C#", [])]
internal sealed class DataTemplateGenerator : IncrementalExtensionsGeneratorBase<DataTemplateInfo>
{
    private protected override EquatableArray<DataTemplateInfo>? GetInfoForType(INamedTypeSymbol namedType)
    {
        if (namedType.IsGenericType)
            return new EquatableArray<DataTemplateInfo>?();

        var builder = ImmutableArray.CreateBuilder<DataTemplateInfo>();
        var GenerationTypeInfo = global::P42.Uno.Extensions.Markup.Generators.GenerationTypeInfo.From(namedType);
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

            if (info.PropertyTypeIsDataTemplateSelector)
                continue;

            CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName)
                .AddParameter("string", "xaml")
                .WithBody(w =>
                {
                    w.AppendLine($"element.{info.PropertyName} = ({info.PropertyTypeFullyQualifiedName})XamlReader.Load(xaml);");
                    w.AppendLine("return element;");
                });

            
            CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName)
                .AddParameter("Type", "templateElementType")
                .WithBody(w =>
                {
                    w.AppendUnindentedLine("#if HAS_UNO");
                    w.AppendLine($"var template = new {info.PropertyTypeFullyQualifiedName}(() => (UIElement)Activator.CreateInstance(templateElementType));");
                    w.AppendUnindentedLine("#else");
                    w.AppendLine($"var template = P42.Uno.Markup.UIElementExtensions.AsTemplate<{info.PropertyTypeFullyQualifiedName}>(templateElementType);");
                    w.AppendUnindentedLine("#endif");
                    w.AppendLine($"element.{info.PropertyName} = template;");
                    w.AppendLine("return element;");
                });
            
            CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName)
                .AddGeneric("TTemplateElement", b => b.AddConstraint($"global::{QualifiedTypeName.UIElement}, new()") )
                .WithBody(w =>
                {
                    w.AppendUnindentedLine("#if HAS_UNO");
                    w.AppendLine($"var template = new {info.PropertyTypeFullyQualifiedName}(() => new TTemplateElement());");
                    w.AppendUnindentedLine("#else");
                    w.AppendLine($"var template = P42.Uno.Markup.UIElementExtensions.GenTemplate<{info.PropertyTypeFullyQualifiedName},TTemplateElement>();");
                    w.AppendUnindentedLine("#endif");
                    w.AppendLine($"element.{info.PropertyName} = template;");
                    w.AppendLine("return element;");
                });
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
