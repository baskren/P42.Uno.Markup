using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

internal abstract class IncrementalExtensionsGeneratorBase<TModel> : IIncrementalGenerator where TModel : BaseModel, IEquatable<TModel>
{
    internal static readonly string ProductVersion = typeof(IncrementalExtensionsGeneratorBase<>)
        .GetTypeInfo()
        .Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
        .InformationalVersion ?? "1.0.0";

    public void Initialize(IncrementalGeneratorInitializationContext context1)
    {
        var syntaxProvider = context1.SyntaxProvider;
        var incrementalValuesProvider = syntaxProvider
            .CreateSyntaxProvider(CanBeNodeOfInterest, Transform)
            .Where(a => a.HasValue);

        context1.RegisterSourceOutput(incrementalValuesProvider, (spc, a) =>
        {
            if (!a.HasValue || a.Value.IsEmpty)
                return;

            GenerateCodeFromInfos(spc, a.Value);
        });

        var incrementalValueProvider = context1
            .CompilationProvider
            .Select((compilation, cancellationToken) =>
                {
                    var typeByMetadataName = compilation.GetTypeByMetadataName("P42.Uno.Markup.Generator.GenerateMarkupForAssemblyAttribute");
                    var attributes = compilation.Assembly.GetAttributes();
                    var builder = ImmutableArray.CreateBuilder<IAssemblySymbol>();
                    foreach (var attributeData in attributes)
                    {
                        var attributeClass = attributeData.AttributeClass;
                        if ((attributeClass != null ? (!attributeClass.Equals(typeByMetadataName, SymbolEqualityComparer.Default) ? 1 : 0) : 1) == 0)
                        {
                            var constructorArgument = attributeData.ConstructorArguments[0];
                            if (constructorArgument.Value is INamedTypeSymbol iNamedTypeSymbol2)
                                builder.Add(iNamedTypeSymbol2.ContainingAssembly);
                        }
                    }
                    return builder.ToImmutableArray();
                })
            .WithComparer(ImmutableArrayComparer.Instance)
            .Select((assemblies, cancellationToken) =>
                {
                    var builder = ImmutableArray.CreateBuilder<EquatableArray<TModel>>();
                    foreach (var assembly in assemblies)
                    {
                        foreach (var publicClass in assembly.GlobalNamespace.GetPublicClasses())
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            if (!publicClass.IsNotImplemented())
                            {
                                var infoForType = GetInfoForType(publicClass);
                                if (infoForType.HasValue)
                                {
                                    if (infoForType.GetValueOrDefault() is EquatableArray<TModel> valueOrDefault)
                                        builder.Add(valueOrDefault);
                                }
                            }
                        }
                    }
                    return builder.ToImmutableArray().AsEquatableArray();
                });

        context1.RegisterSourceOutput(incrementalValueProvider, (context3, infosArray) =>
        {
            foreach (EquatableArray<TModel> infos in infosArray)
            {
                context3.CancellationToken.ThrowIfCancellationRequested();
                if (!infos.IsEmpty)
                    GenerateCodeFromInfos(context3, infos);
            }
        });
    }

    private static bool CanBeNodeOfInterest(SyntaxNode node, CancellationToken _)
    {
        if (node is not ClassDeclarationSyntax declarationSyntax)
            return false;

        if (Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.PartialKeyword))
            return true;

        return declarationSyntax.BaseList is BaseListSyntax baseList && baseList.Types.Count > 0;
    }

    private EquatableArray<TModel>? Transform(GeneratorSyntaxContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var node = (ClassDeclarationSyntax)context.Node;
        var declaredSymbol = Microsoft.CodeAnalysis.CSharp.CSharpExtensions.GetDeclaredSymbol(context.SemanticModel, node, ct);
        if (declaredSymbol == null || declaredSymbol.IsNotImplemented())
            return new EquatableArray<TModel>?();
        return declaredSymbol.DeclaringSyntaxReferences[0].GetSyntax(ct) != node ? new EquatableArray<TModel>?() : this.GetInfoForType(declaredSymbol);
    }

    protected static bool IsDependencyProperty(ISymbol symbol)
        => symbol switch
        {
            IFieldSymbol iFieldSymbol => iFieldSymbol.IsStatic 
                && iFieldSymbol.Type.Name == "DependencyProperty" 
                && iFieldSymbol.Type.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.DependencyProperty",
            IPropertySymbol iPropertySymbol => iPropertySymbol.IsStatic 
                && iPropertySymbol.Type.Name == "DependencyProperty" 
                && iPropertySymbol.Type.GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.DependencyProperty",
            _ => false,
        };
    

    private void GenerateCodeFromInfos(SourceProductionContext context, EquatableArray<TModel> infos)
    {
        string clrNamespace = infos[0].GenerationTypeInfo.TypeContainingNamespace;

        if (clrNamespace == "Microsoft.UI.Xaml.Controls.Primitives")
            clrNamespace = "Microsoft.UI.Xaml.Controls";

        Accessibility accessModifier = GeneratedClassAccessibilityOverride ?? infos[0].GenerationTypeInfo.DeclaredAccessibility;
        ClassBuilder builder = CodeBuilder
            .Create(clrNamespace)
            .Nullable(NullableState.Enable)
            .AddClass(GetClassName(infos[0].GenerationTypeInfo.TypeName))
            .WithAccessModifier(accessModifier)
            .MakeStaticClass()
            .DisableWarning("Uno0001")
            .AddNamespaceImport("System")
            .AddNamespaceImport("System.Collections.Generic")
            .AddNamespaceImport("System.Runtime.CompilerServices")
            .AddNamespaceImport("System.Linq")
            .AddNamespaceImport("System.Linq.Expressions")
            .AddNamespaceImport("Microsoft.UI.Xaml")
            .AddNamespaceImport("Microsoft.UI.Xaml.Data")
            .AddNamespaceImport("Microsoft.UI.Xaml.Markup")
            .AddNamespaceImport("Uno.Extensions.Markup");

        if (infos[0].GenerationTypeInfo.TypeContainingNamespace == "Microsoft.UI.Xaml.Controls.Primitives")
            builder.AddNamespaceImport("Microsoft.UI.Xaml.Controls.Primitives");

        
        GenerateCodeFromInfosCore(builder, infos, context, context.CancellationToken);
        
        AddSource(context, builder, infos[0].GenerationTypeInfo);
    }

    private protected void AddSource(
      SourceProductionContext context,
      ClassBuilder builder,
      GenerationTypeInfo generationTypeInfo,
      string? fileNamePrefix = null)
    {
        if (!builder.Methods.Any())
            return;
        builder.AddNamespaceImport("System.CodeDom.Compiler");
        foreach (var method in (IEnumerable<MethodBuilder>)builder.Methods)
            method.AddAttribute($"GeneratedCode(\"P42.Uno.Markup\", \"{ProductVersion}\")");
        var str1 = builder.Build();
        var str2 = this.GetGeneratedFileName(builder, generationTypeInfo);
        if (!string.IsNullOrEmpty(fileNamePrefix))
            str2 = $"{fileNamePrefix}_{str2}";
        context.AddSource(str2 + ".g.cs", str1);
    }

    private protected virtual Accessibility? GeneratedClassAccessibilityOverride
    {
        get => new Accessibility?();
    }

    private protected virtual string GetGeneratedFileName(
      ClassBuilder builder,
      GenerationTypeInfo generationTypeInfo)
    {
        return builder.FullyQualifiedName;
    }

    private protected abstract EquatableArray<TModel>? GetInfoForType(INamedTypeSymbol namedType);

    private protected abstract string GetClassName(string typeName);

    private protected abstract void GenerateCodeFromInfosCore(
      ClassBuilder builder,
      EquatableArray<TModel> infos,
      SourceProductionContext context,
      CancellationToken cancellationToken);
}
