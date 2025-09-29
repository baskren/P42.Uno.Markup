using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using P42.Uno.Extensions.Markup.Generators.Extensibility;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

[Generator("C#", [])]
internal sealed class DependencyPropertyExtensionGenerator :
  IncrementalExtensionsGeneratorBase<DependencyPropertyExtensionInfo>
{

    private protected override EquatableArray<DependencyPropertyExtensionInfo>? GetInfoForType(INamedTypeSymbol namedType)
    {
        if (!namedType.IsDependencyObject() || namedType.IsGenericType)
            return new EquatableArray<DependencyPropertyExtensionInfo>?();

        if (namedType.Name is "Binding" or "Setter")
            return new EquatableArray<DependencyPropertyExtensionInfo>?();

        var generationTypeIsFrameworkElement = namedType.IsFrameworkTemplate();
        for (var type = namedType; type != null; type = type.BaseType)
        {
            if (type.Name == "FrameworkElement" && type.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.FrameworkElement")
            {
                generationTypeIsFrameworkElement = true;
                break;
            }
        }

        var membersForGeneration = namedType.GetSymbolsForGeneration<IPropertySymbol>();
        var iPropertySymbols = membersForGeneration
            .OfType<IPropertySymbol>()
            .Where(x => x.IsCollectionWithAddMethod() || x.HasPublicSetter());
        var builder = ImmutableArray.CreateBuilder<DependencyPropertyExtensionInfo>();
        var typeInfo = GenerationTypeInfo.From(namedType);

        foreach (IPropertySymbol property in iPropertySymbols)
        {
            if (
                !property.IsStatic 
                && !property.IsIndexer 
                && !property.Name.Contains(".") 
                && property.DeclaredAccessibility != Accessibility.Private 
                && property.DeclaredAccessibility != Accessibility.Protected 
                && !IsIgnoredProperty(property) 
                && !property.IsNotImplemented() 
                && (property.Name != "DataContext")
               )
            {
                bool isDependencyProperty = ImmutableArrayExtensions.Any(membersForGeneration, m => m.Name == property.Name + "Property");
                builder.Add(DependencyPropertyExtensionInfo.From(
                    property, 
                    typeInfo, 
                    isDependencyProperty, 
                    generationTypeIsFrameworkElement, 
                    !namedType.IsSealed && IsShadowing(property, namedType)
                    ));
            }
        }

        return new EquatableArray<DependencyPropertyExtensionInfo>?(builder.ToImmutable().AsEquatableArray());
    }

    private static string AdjustParameterName(string parameterName)
        => parameterName == "element" 
            ? "value" 
            : parameterName.EscapeIdentifier();
    

    private static bool IsIgnoredProperty(IPropertySymbol property)
    {
        return property.Name switch
        {
            "TemplatedParent" or "XamlRoot" => true,
            "Count" or "IsReadOnly" => property.ContainingType.Name == "ColorKeyFrameCollection",
            "RoutedEvent" => property.ContainingType.Name == "EventTrigger",
            "AreDimensionsConstrained" or "RenderPhase" => property.ContainingType.Name == "FrameworkElement",
            "IsParsing" => property.ContainingType.Name is "FrameworkElement" or "ResourceDictionary",
            "BasedOn" => property.ContainingType.Name == "Style",
            "TargetType" => property.ContainingType.Name is "Style" or "ControlTemplate",
            "Name" => property.ContainingType.Name is "VisualState" or "VisualStateGroup",
            _ => property.Name == "ItemsPanelRoot" && property.ContainingType.Name == "ItemsControl"
        };
    }

    private static bool IsShadowing(IPropertySymbol property, INamedTypeSymbol namedType)
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

    private protected override string GetClassName(string typeName) => typeName + "Markup";

    private protected override void GenerateCodeFromInfosCore(
      ClassBuilder classBuilder,
      EquatableArray<DependencyPropertyExtensionInfo> infos,
      SourceProductionContext context,
      CancellationToken cancellationToken)
    {
        var sb = new StringBuilder();

        foreach (var info in infos)
        {
            cancellationToken.ThrowIfCancellationRequested();
            GeneratePropertyExtensions(classBuilder, info);
        }
        infos.FirstOrDefault();
    }

    private void GeneratePropertyExtensions(
      ClassBuilder classBuilder,
      DependencyPropertyExtensionInfo info)
    {
        var returnTypeName = info.PropertyTypeFullyQualified;

        File.AppendAllText("C:/temp/Dependencies.txt", $"{info.GenerationTypeInfo.TypeFullyQualifiedName}.{info.PropertyName}({info.PropertyTypeFullyQualified})\n");

        if (info.PropertyHasPublicSetter)
        {
            /*
            var parameterName = AdjustParameterName(info.PropertyName.Camelcase());
            var methodBuilder = CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName, info.IsNotSealedAndIsShadowing)
                .AddParameter(returnTypeName, parameterName);

            if (returnTypeName == "global::Microsoft.UI.Xaml.ResourceDictionary")
                methodBuilder.WithBody(w =>
                {
                    if (info.PropertyName == "Resources")
                    {
                        w.AppendLine("element.Resources ??= new ResourceDictionary();");
                        w.AppendLine($"element.Resources.MergedDictionaries.Add({parameterName});");
                    }
                    else
                        w.AppendLine($"element.{info.PropertyName} = {parameterName};");
                    w.AppendLine("return element;");
                });
            else
                methodBuilder.WithBody(w =>
                {
                    if (info.PropertyIsDependencyObjectButNotFrameworkElement)
                        w.AppendLine($"ResourceObserver.SetResourceParent({parameterName}, element);");
                    else if (info.PropertyIsCollection)
                    {
                        foreach (MethodParameterInfo methodParameterType in info.MethodParameterTypes)
                        {
                            if (methodParameterType.IsDependencyObject)
                                w.ForEach("var item", parameterName).WithBody(_ => _.If("item is Microsoft.UI.Xaml.DependencyObject dObj").WithBody(ifWrite => ifWrite.AppendLine("ResourceObserver.SetResourceParent(dObj, element);")).EndIf());
                        }
                    }

                    string str = $"element.{info.PropertyName} = {parameterName}";
                    if (returnTypeName == "global::Microsoft.UI.Xaml.Style")
                        w.AppendLine($"global::Uno.Extensions.Markup.LoadingObserver.AddLoadingCallback(element, _ => {str});");
                    else
                        w.AppendLine(str + ";");
                    w.AppendLine("return element;");
                });
            */

            ExtensibilityLocator.Extensions.ForEach(x =>
            {
                if (!x.CanExtend(info.PropertyTypeFullyQualified))
                    return;
                x.WriteDependencyPropertyExtensions(classBuilder, info, (methodName) => CreatePropertyBuilder(classBuilder, info.GenerationTypeInfo, methodName));
            });

            /*
            if (info.PropertyIsCollection)
                CreateCollectionExtension(classBuilder, info);
            */
            if (!info.IsDependencyProperty)
                return;

            /*
            if (!info.IsTemplateType)
            {
                CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName)
                    .AddGeneric("TSource")
                    .AddParameter("Func<TSource>", "propertyBinding")
                    .AddParameter("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression = null")
                    .WithBody(w =>
                    {
                        if (info.GenerationTypeInfo.IsSealed)
                            w.AppendLine($"return {info.PropertyName}(element, _ => _.Binding(propertyBinding, propertyBindingExpression));");
                        else
                            w.AppendLine($"return {info.PropertyName}<T>(element, _ => _.Binding(propertyBinding, propertyBindingExpression));");
                    });
                CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName)
                    .AddGeneric("TSource")
                    .AddParameter("Func<TSource>", "propertyBinding")
                    .AddParameter($"Func<TSource, {returnTypeName}>", "convertDelegate")
                    .AddParameter("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression = null")
                    .WithBody(w =>
                    {
                        if (info.GenerationTypeInfo.IsSealed)
                            w.AppendLine($"return {info.PropertyName}(element, _ => _.Binding(propertyBinding, propertyBindingExpression).Convert(convertDelegate));");
                        else
                            w.AppendLine($"return {info.PropertyName}<T>(element, _ => _.Binding(propertyBinding, propertyBindingExpression).Convert(convertDelegate));");
                    });
            }
            
            CreatePropertyBuilder(ref classBuilder, info.GenerationTypeInfo, info.PropertyName)
                .AddParameter($"Action<IDependencyPropertyBuilder<{returnTypeName}>>", "configureProperty")
                .WithBody(w =>
                {
                    w.AppendLine($"var builder = DependencyPropertyBuilder<{returnTypeName}>.Instance;");
                    w.AppendLine("configureProperty(builder);");
                    w.AppendLine($"builder.SetBinding(element, {info.GenerationTypeInfo.TypeFullyQualifiedName}.{info.PropertyName}Property, \"{info.PropertyName}\");");
                    w.AppendLine("return element;");
                });
               */ 
        }
        else
        {
            /*
            if (!info.PropertyIsCollection || info.PropertyDeclaredAccessibility != Accessibility.Public)
                return;
            CreateCollectionExtension(classBuilder, info);
            */
        }
    }

    private void CreateCollectionExtension(ClassBuilder builder, DependencyPropertyExtensionInfo info)
    {
        EquatableArray<MethodParameterInfo> methodParameterTypes = info.MethodParameterTypes;
        string parameterName = info.PropertyName.EndsWith("s") || info.PropertyName == "Children" ? info.PropertyName.Camelcase() : info.PropertyName.Camelcase() + "s";
        parameterName = AdjustParameterName(parameterName);
        foreach (MethodParameterInfo methodParameterInfo in methodParameterTypes)
        {
            MethodParameterInfo parameterSymbol = methodParameterInfo;
            CreatePropertyBuilder(builder, info.GenerationTypeInfo, info.PropertyName).AddParameter($"params {parameterSymbol.ParameterTypeFullyQualified}[]", parameterName).WithBody(w =>
            {
                if (info.PropertyHasPublicSetter && info.PropertyTypeIsReferenceTypeOrNullableValueType && info.PropertyTypeIsInstantiable)
                    w.AppendLine($"element.{info.PropertyName} ??= new {info.PropertyTypeFullyQualified}();");
                else if (info.PropertyTypeIsReferenceTypeOrNullableValueType)
                    w.If($"element.{info.PropertyName} == null").WithBody(x => x.AppendLine($"throw new NullReferenceException(\"{info.PropertyName}\");")).EndIf();
                w.ForEach("var item", parameterName).WithBody(_ =>
                {
                    if (parameterSymbol.IsDependencyObject)
                        _.If("item is Microsoft.UI.Xaml.DependencyObject dObj").WithBody(ifWrite => ifWrite.AppendLine("ResourceObserver.SetResourceParent(dObj, element);")).EndIf();
                    if (parameterSymbol.IsReferenceTypeOrNullableValueType)
                        _.If("item is null").WithBody(ifWrite => ifWrite.AppendLine("continue;")).EndIf();
                    if (info.GenerationTypeIsFrameworkElement && parameterSymbol.IsTextElement)
                        _.If("element is Microsoft.UI.Xaml.FrameworkElement fe").WithBody(ifWrite => ifWrite.AppendLine("global::Uno.Extensions.Markup.TextElementMarkup.ApplyDataContext(fe, item);")).EndIf();
                    _.AppendLine($"element.{info.PropertyName}.Add(item);");
                });
                w.AppendLine("return element;");
            });
        }
    }

    internal static MethodBuilder CreatePropertyBuilder(
      ClassBuilder classBuilder,
      GenerationTypeInfo generationTypeInfo,
      string propertyName,
      bool forceStronglyTyped = false)
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
