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
internal sealed class AttachedPropertyGenerator :
  IncrementalExtensionsGeneratorBase<AttachedPropertyInfo>
{
    private protected override void GenerateCodeFromInfosCore(
      ClassBuilder builder,
      EquatableArray<AttachedPropertyInfo> infos,
      SourceProductionContext context,
      CancellationToken cancellationToken)
    {
        if (infos.FirstOrDefault() is not AttachedPropertyInfo attachedPropertyInfo)
            return;

        GenerationTypeInfo generationTypeInfo = attachedPropertyInfo.GenerationTypeInfo;
        string typeName = generationTypeInfo.TypeName;



        File.AppendAllText("C:/temp/Attached.txt", $"{generationTypeInfo.TypeFullyQualifiedName}");



        CreateOptionParameterExtension(builder, generationTypeInfo, infos);
        CreateMethodBuilder(builder, generationTypeInfo).AddParameter($"Action<{typeName}PropertyBuilder>", "configure").WithBody(w =>
        {
            w.AppendLine($"var builder = {typeName}PropertyBuilder.GetInstance(element);");
            w.AppendLine("configure(builder);");
            w.AppendLine("return element;");
        });
        CreatePropertyBuilder(generationTypeInfo, infos, context);
        CreateStylePropertyBuilder(generationTypeInfo, infos, context);
        
    }

    private protected override string GetClassName(string typeName) => typeName + "Markup";

    private protected override EquatableArray<AttachedPropertyInfo>? GetInfoForType(
      INamedTypeSymbol namedType)
    {
        return null;

        if (namedType.Name == "VisualStateManager" || namedType.IsGenericType)
            return null;

        var members = namedType.GetMembers();
        var source = from x in members.OfType<IMethodSymbol>()
                                            where x.IsStatic
                                            select x;
        if (!source.Any())
            return null;

        var enumerable = members.Where(IsDependencyProperty);
        if (!enumerable.Any())
            return null;

        var builder = ImmutableArray.CreateBuilder<AttachedPropertyInfo>();
        var generationTypeInfo = GenerationTypeInfo.From(namedType);
        foreach (var item in enumerable)
        {
            string name = item.Name.Substring(0, item.Name.Length - "Property".Length);
            if (source.FirstOrDefault((IMethodSymbol x) => x.Name == "Get" + name) is IMethodSymbol val)
            {
                var returnType = val.ReturnType;
                if (returnType is INamedTypeSymbol val2)
                {
                    builder.Add(new AttachedPropertyInfo
                        (
                            name, 
                            val2.GetFullyQualifiedTypeIncludingGlobal(), 
                            val2.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T, 
                            "global::" + generationTypeInfo.TypeContainingNamespace + "." + namedType.Name + "." + item.Name, generationTypeInfo
                        ));
                }
            }
        }
        if (builder.Count == 0)
            return null;

        return builder.OrderBy((AttachedPropertyInfo x) => x.Name).ToImmutableArray().AsEquatableArray();
    }

    private void CreateStylePropertyBuilder(
      GenerationTypeInfo typeInfo,
      EquatableArray<AttachedPropertyInfo> attachedProperties,
      SourceProductionContext context)
    {
        ClassBuilder builder1 = CodeBuilder
            .Create(typeInfo.TypeContainingNamespace)
            .Nullable(NullableState.Enable)
            .AddClass("CSharpMarkupAttachedPropertyStyleBuilderExtensions")
            .MakeStaticClass().WithAccessModifier((Accessibility)6)
            .DisableWarning("Uno0001")
            .AddNamespaceImport("System")
            .AddNamespaceImport("System.Collections.Generic")
            .AddNamespaceImport("System.Runtime.CompilerServices")
            .AddNamespaceImport("System.Linq")
            .AddNamespaceImport("System.Linq.Expressions")
            .AddNamespaceImport("Microsoft.UI.Xaml")
            .AddNamespaceImport("Microsoft.UI.Xaml.Data")
            .AddNamespaceImport("Uno.Extensions.Markup")
            .AddNamespaceImport(typeInfo.TypeContainingNamespace);
        builder1
            .AddMethod(typeInfo.TypeName)
            .WithAccessModifier(typeInfo.DeclaredAccessibility)
            .MakeStaticMethod()
            .WithReturnType("StyleBuilder<T>")
            .AddGeneric("T", x => x.AddConstraint("global::Microsoft.UI.Xaml.DependencyObject"))
            .AddParameter("this StyleBuilder<T>", "builder")
            .AddParameter($"Action<{typeInfo.TypeName}PropertyStyleBuilder<T>>", "configureBuilder")
            .WithBody(w =>
        {
            w.AppendLine($"var styleBuilder = new {typeInfo.TypeName}PropertyStyleBuilder<T>(builder);");
            w.AppendLine("configureBuilder(styleBuilder);");
            w.AppendLine("return builder;");
        });
        AddSource(context, builder1, typeInfo, typeInfo.TypeName);
        ClassBuilder builder = CodeBuilder
            .Create(typeInfo.TypeContainingNamespace)
            .Nullable(NullableState.Enable)
            .AddClass(typeInfo.TypeName + "PropertyStyleBuilder")
            .WithAccessModifier(typeInfo.DeclaredAccessibility)
            .AddGeneric("T", x => x.AddConstraint("global::Microsoft.UI.Xaml.DependencyObject"))
            .DisableWarning("Uno0001")
            .AddNamespaceImport("System")
            .AddNamespaceImport("System.Collections.Generic")
            .AddNamespaceImport("System.Runtime.CompilerServices")
            .AddNamespaceImport("System.Linq")
            .AddNamespaceImport("System.Linq.Expressions")
            .AddNamespaceImport("Microsoft.UI.Xaml")
            .AddNamespaceImport("Microsoft.UI.Xaml.Data")
            .AddNamespaceImport("Uno.Extensions.Markup")
            .AddNamespaceImport(typeInfo.TypeContainingNamespace);
        builder
            .AddConstructor(new Accessibility?((Accessibility)6))
            .AddParameter("StyleBuilder<T>", "builder")
            .WithBody(w => w.AppendLine("_builder = builder;"));
        builder
            .AddProperty("_builder")
            .SetType("StyleBuilder<T>")
            .MakePrivateProperty()
            .WithReadonlyValue();
        string builderType = builder.Name + "<T>";
        foreach (AttachedPropertyInfo attachedProperty in attachedProperties)
        {
            AttachedPropertyInfo prop = attachedProperty;
            /*
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builderType).AddParameter(prop.PropertyTypeFullyQualified, prop.Name.Camelcase()).WithBody(w =>
            {
                w.If("_builder is null").WithBody(x => x.AppendLine("throw new Exception(\"The StyleBuilder is null or has not been set.\");")).EndIf();
                w.AppendLine($"_builder.Add({prop.DependencyProperty}, \"{prop.Name}\", {prop.Name.Camelcase()});");
                w.AppendLine("return this;");
            });
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builderType).AddGeneric("TSource").AddParameter("Func<TSource>", "propertyBinding").AddParameter("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression = null").WithBody(w => w.AppendLine($"return {prop.Name}(_ => _.Binding(propertyBinding, propertyBindingExpression));"));
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builderType).AddGeneric("TSource").AddParameter("Func<TSource>", "propertyBinding").AddParameter($"Func<TSource, {prop.PropertyTypeFullyQualified}>", "convertDelegate").AddParameter("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression = null").WithBody(w => w.AppendLine($"return {prop.Name}(_ => _.Binding(propertyBinding, propertyBindingExpression).Convert(convertDelegate));"));
            
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builderType).AddParameter($"Action<IDependencyPropertyBuilder<{prop.PropertyTypeFullyQualified}>>", "configureProperty").WithBody(w =>
            {
                w.If("_builder is null").WithBody(x => x.AppendLine("throw new Exception(\"The StyleBuilder is null or has not been set.\");")).EndIf();
                w.AppendLine($"_builder.Add({prop.DependencyProperty}, \"{prop.Name}\", \"{prop.Name}\", configureProperty);");
                w.AppendLine("return this;");
            });
            
            */
            ExtensibilityLocator.Extensions.ForEach(x =>
            {
                if (!x.CanExtend(prop.PropertyTypeFullyQualified))
                    return;
                x.WriteAttachedPropertyBuilderExtensions(prop, () => CreatePropertyBuilder(builder, prop).WithReturnType(builderType));
            });
        }
        AddSource(context, builder, typeInfo);
    }

    private void CreatePropertyBuilder(
      GenerationTypeInfo typeInfo,
      EquatableArray<AttachedPropertyInfo> attachedProperties,
      SourceProductionContext context)
    {
        ClassBuilder builder = CodeBuilder
            .Create(typeInfo.TypeContainingNamespace)
            .Nullable(NullableState.Enable)
            .AddClass(typeInfo.TypeName + "PropertyBuilder")
            .WithAccessModifier(typeInfo.DeclaredAccessibility)
            .DisableWarning("Uno0001")
            .AddNamespaceImport("System")
            .AddNamespaceImport("System.Collections.Generic")
            .AddNamespaceImport("System.Runtime.CompilerServices")
            .AddNamespaceImport("System.Linq")
            .AddNamespaceImport("System.Linq.Expressions")
            .AddNamespaceImport("Microsoft.UI.Xaml")
            .AddNamespaceImport("Microsoft.UI.Xaml.Data")
            .AddNamespaceImport("Uno.Extensions.Markup")
            .AddNamespaceImport(typeInfo.TypeContainingNamespace);
        builder
            .AddProperty("_instance")
            .SetType(builder.Name + "?")
            .WithAccessModifier((Accessibility)1)
            .MakeStatic()
            .WithValue("default", CodeGenHelpers.ValueType.Null);
        builder
            .AddProperty("_weakElement")
            .SetType("WeakReference<DependencyObject>?")
            .MakePrivateProperty()
            .UseAutoProps();
        builder
            .AddProperty("_element")
            .SetType("DependencyObject?")
            .MakePrivateProperty()
            .WithGetter
            (w =>
                {
                    w.If("_weakElement is not null && _weakElement.TryGetTarget(out var element)").WithBody(x => x.AppendLine("return element;")).EndIf();
                    w.AppendLine("return null;");
                }
            )
            .WithSetter
            (w => 
                w.If("value is null")
                    .WithBody(x => x.AppendLine("_weakElement = null;"))
                .Else()
                    .WithBody(x => x.AppendLine("_weakElement = new WeakReference<DependencyObject>(value);"))
                .EndIf()
            );
        builder
            .AddConstructor(new Accessibility?((Accessibility)1))
            .WithBody(w => w.AppendLine("// Intentionally left empty"));
        builder
            .AddMethod("GetInstance")
            .MakePublicMethod()
            .MakeStaticMethod()
            .WithReturnType(builder.Name)
            .AddParameter("DependencyObject", "element")
            .WithBody(w =>
            {
                w.If("_instance is null").WithBody(x => x.AppendLine($"_instance = new {builder.Name}();")).EndIf();
                w.AppendLine("_instance._element = element;");
                w.AppendLine("return _instance;");
            });

        foreach (AttachedPropertyInfo attachedProperty in attachedProperties)
        {
            AttachedPropertyInfo prop = attachedProperty;

            /*
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builder.Name).AddParameter(prop.PropertyTypeFullyQualified, prop.Name.Camelcase()).WithBody(w =>
            {
                w.If("_element is null").WithBody(x => x.AppendLine("throw new Exception(\"The Element is null or has not been set.\");")).EndIf();
                w.AppendLine($"_element.SetValue({prop.DependencyProperty}, {prop.Name.Camelcase()});");
                w.AppendLine("return this;");
            });
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builder.Name).AddGeneric("TSource").AddParameter("Func<TSource>", "propertyBinding").AddParameter("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression = null").WithBody(w => w.AppendLine($"return {prop.Name}(_ => _.Binding(propertyBinding, propertyBindingExpression));"));
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builder.Name).AddGeneric("TSource").AddParameter("Func<TSource>", "propertyBinding").AddParameter($"Func<TSource, {prop.PropertyTypeFullyQualified}>", "convertDelegate").AddParameter("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression = null").WithBody(w => w.AppendLine($"return {prop.Name}(_ => _.Binding(propertyBinding, propertyBindingExpression).Convert(convertDelegate));"));
            
            builder.AddMethod(prop.Name).MakePublicMethod().WithReturnType(builder.Name).AddParameter($"Action<IDependencyPropertyBuilder<{prop.PropertyTypeFullyQualified}>>", "configureProperty").WithBody(w =>
            {
                w.If("_element is null").WithBody(x => x.AppendLine("throw new Exception(\"The Element is null or has not been set.\");")).EndIf();
                w.AppendLine($"var builder = DependencyPropertyBuilder<{prop.PropertyTypeFullyQualified}>.Instance;");
                w.AppendLine("configureProperty(builder);");
                w.AppendLine($"builder.SetBinding(_element, {prop.DependencyProperty}, \"{prop.Name}\");");
                w.AppendLine("return this;");
            });
            */

            ExtensibilityLocator.Extensions.ForEach(x =>
            {
                if (!x.CanExtend(prop.PropertyTypeFullyQualified))
                    return;
                x.WriteAttachedPropertyBuilderExtensions(prop, () => CreatePropertyBuilder(builder, prop));
            });
            AddDataTemplateOverload(builder, prop);
            AddDataTemplateSelectorOverload(builder, prop);
        }
        AddSource(context, builder, typeInfo);
    }

    private static void CreateOptionParameterExtension(
      ClassBuilder builder,
      GenerationTypeInfo info,
      EquatableArray<AttachedPropertyInfo> attachedProperties)
    {
        MethodBuilder methodBuilder = CreateMethodBuilder(builder, info);
        foreach (AttachedPropertyInfo attachedProperty in attachedProperties)
        {
            string typeFullyQualified = attachedProperty.PropertyTypeFullyQualified;
            if (!attachedProperty.PropertyTypeIsNullableValueType)
                typeFullyQualified += "?";

            methodBuilder
                .AddParameterWithDefaultValue(typeFullyQualified, attachedProperty.Name.Camelcase(), -1);
        }
        methodBuilder.WithBody(w =>
        {
            foreach (AttachedPropertyInfo attachedProperty in attachedProperties)
            {
                AttachedPropertyInfo prop = attachedProperty;
                string condition = prop.Name.Camelcase() + " != default";
                string paramValue = prop.Name.Camelcase();
                if (prop.PropertyTypeIsNullableValueType)
                {
                    condition = prop.Name.Camelcase() + ".HasValue";
                    paramValue += ".Value";
                }
                w.If(condition)
                    .WithBody(x => x.AppendLine($"element.SetValue({prop.DependencyProperty}, {paramValue});"))
                  .EndIf();
            }
            w.AppendLine("return element;");
        });
    }

    private static MethodBuilder CreateMethodBuilder(ClassBuilder builder, GenerationTypeInfo info)
    {
        return builder
            .AddMethod(info.TypeName)
            .MakePublicMethod()
            .MakeStaticMethod()
            .AddAttribute("global::Uno.Extensions.Markup.Internals.MarkupExtensionAttribute")
            .AddGeneric("T", x => x.AddConstraint("DependencyObject"))
            .AddParameter("this T", "element")
            .WithReturnType("T");
    }

    private static MethodBuilder CreatePropertyBuilder(
      ClassBuilder builder,
      AttachedPropertyInfo prop)
    {
        return builder
            .AddMethod(prop.Name)
            .MakePublicMethod()
            .WithReturnType(builder.Name);
    }

    private static void AddDataTemplateOverload(ClassBuilder builder, AttachedPropertyInfo prop)
    {
        if (prop.PropertyTypeFullyQualified != "global::Microsoft.UI.Xaml.DataTemplate")
            return;
        CreatePropertyBuilder(builder, prop).AddGeneric("TItem").AddParameter("Func<TItem, UIElement>", "dataTemplateDelegate").WithBody(w =>
        {
            w.AppendUnindentedLine("#nullable disable");
            w.AppendLine($"_element.SetValue({prop.DependencyProperty}, DataTemplateHelpers.DataTemplate(() => dataTemplateDelegate(default)));");
            w.AppendUnindentedLine("#nullable enable");
            w.AppendLine("return this;");
        });
    }

    private static void AddDataTemplateSelectorOverload(
      ClassBuilder builder,
      AttachedPropertyInfo prop)
    {
        if (prop.PropertyTypeFullyQualified != "global::Microsoft.UI.Xaml.DataTemplate")
            return;
        CreatePropertyBuilder(builder, prop).AddGeneric("TItem").AddParameter("Action<TItem, MarkupDataTemplateSelectorBuilder<TItem>>", "configureDataTemplateSelector").WithBody(w =>
        {
            w.AppendLine("var builder = new MarkupDataTemplateSelectorBuilder<TItem>();");
            w.AppendUnindentedLine("#nullable disable");
            w.AppendLine("configureDataTemplateSelector(default, builder);");
            w.AppendUnindentedLine("#nullable enable");
            w.AppendLine($"_element.SetValue({prop.DependencyProperty}, (DataTemplateSelector)builder);");
            w.AppendLine("return this;");
        });
    }
}
