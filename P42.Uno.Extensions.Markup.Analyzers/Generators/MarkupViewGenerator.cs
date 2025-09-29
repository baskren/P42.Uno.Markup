using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using P42.Uno.Extensions.Markup.Analyzers.Helpers;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers.Generators;

[Generator("C#", [])]
public sealed class MarkupViewGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var incrementalValuesProvider1 = context
            .AdditionalTextsProvider
            .Where(a => a.Path.EndsWith(".xaml", StringComparison.OrdinalIgnoreCase))
            .Select((a, c) => GetClass(a))
            .Where(x => !string.IsNullOrEmpty(x))
            .WithTrackingName("AdditionalTextsStep");

        var syntaxProvider = context.SyntaxProvider;

        var incrementalValuesProvider2 =
            syntaxProvider.CreateSyntaxProvider(PageSyntaxPredicate, PageSyntaxTransform)
                .Where(x => x.HasValue)
                .WithComparer(MarkupContextComparer.Instance)
                .WithTrackingName("SyntaxProviderStep")
                .Combine(incrementalValuesProvider1.Collect())
                .WithTrackingName("CombinedFinalStep");

        context.RegisterSourceOutput(incrementalValuesProvider2, new Action<SourceProductionContext, (MarkupViewContext?, ImmutableArray<string>)>(Execute));
    }

    private void Execute(
      SourceProductionContext context,
      (MarkupViewContext? MarkupViewContext, ImmutableArray<string> XamlClasses) contextAndXaml)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        var markupViewContext = contextAndXaml.MarkupViewContext.Value;

        if (contextAndXaml.XamlClasses.Contains(markupViewContext.QualifiedTypeName))
            return;

        ClassBuilder classBuilder = CodeBuilder
            .Create(markupViewContext.Namespace)
            .AddNamespaceImport("Microsoft.UI.Xaml.Data")
            .AddNamespaceImport("System.Runtime.CompilerServices")
            .AddClass(markupViewContext.Name)
            .AddAttribute("Bindable");

        if (markupViewContext.IsUIElement)
            classBuilder = classBuilder.AddAttribute("CreateNewOnMetadataUpdate");

        context.AddSource(classBuilder.FullyQualifiedName + ".g.cs", classBuilder.Build());
    }

    private MarkupViewContext? PageSyntaxTransform(
      GeneratorSyntaxContext context,
      CancellationToken cancellation)
    {
        var declarationSyntax = Unsafe.As<ClassDeclarationSyntax>(context.Node);
        if (Microsoft.CodeAnalysis.CSharp.CSharpExtensions
            .GetDeclaredSymbol(context.SemanticModel, declarationSyntax, cancellation) 
            is not INamedTypeSymbol declaredSymbol 
            || declaredSymbol.BaseType == null
            )
            return new MarkupViewContext?();

        if (declaredSymbol.IsAbstract 
            || declaredSymbol.IsStatic 
            || !IsDerivedFromDependencyObject(declaredSymbol.BaseType)
            )
            return new MarkupViewContext?();

        if (declaredSymbol.DeclaringSyntaxReferences[0].GetSyntax(cancellation) != context.Node)
            return new MarkupViewContext?();

        return ImmutableArrayExtensions.Any(declaredSymbol.GetAttributes(), (Func<AttributeData, bool>)(
            a => a.AttributeClass is INamedTypeSymbol attributeClass 
                    && attributeClass.Name == "BindableAttribute" 
                    && ((ITypeSymbol)attributeClass).GetFullyQualifiedTypeExcludingGlobal() == "Microsoft.UI.Xaml.Data.BindableAttribute"
        )) 
            ? new MarkupViewContext?() 
            : new MarkupViewContext?(new MarkupViewContext(declaredSymbol));
    }

    private static bool IsDerivedFromDependencyObject(INamedTypeSymbol baseSymbol)
    => !((ITypeSymbol)baseSymbol).IsResourceDictionary() && ((ITypeSymbol)baseSymbol).IsDependencyObject();
    

    private static bool PageSyntaxPredicate(SyntaxNode node, CancellationToken cancellation)
    => node is ClassDeclarationSyntax declarationSyntax
        && Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.PartialKeyword)
        && !Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.StaticKeyword)
        && !Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.AbstractKeyword)
        && declarationSyntax.BaseList != null;
    

    private static string GetClass(AdditionalText additionalText)
    {
        if (additionalText.GetText(new CancellationToken()) is SourceText text)
        {
            if (text.Length != 0)
            {
                try
                {
                    return XDocument
                        .Parse(text.ToString())
                        .Root
                        .Attributes()
                        .FirstOrDefault(x =>
                        {
                            var name = x.Name;
                            if (name?.LocalName == "Class")
                            {
                                var xNamespace = name.Namespace;
                                if (xNamespace != null)
                                    return xNamespace.NamespaceName == "http://schemas.microsoft.com/winfx/2006/xaml";
                            }
                            return false;
                        })?.Value ?? string.Empty;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        return string.Empty;
    }
}
