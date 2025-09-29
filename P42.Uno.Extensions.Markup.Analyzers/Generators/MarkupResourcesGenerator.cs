using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using P42.Uno.Extensions.Markup.Analyzers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers.Generators;

[Generator("C#", [])]
public sealed class MarkupResourcesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var incrementalValuesProvider = context
            .SyntaxProvider
            .CreateSyntaxProvider(ResourceDictionarySyntaxPredicate, ResourceDictionarySyntaxTransform)
            .Where(x => x.HasValue)
            .WithComparer(MarkupContextComparer.Instance)
            .WithTrackingName("SyntaxProviderStep");

        context.RegisterSourceOutput(incrementalValuesProvider, new Action<SourceProductionContext, MarkupViewContext?>(Execute));
    }

    private void Execute(SourceProductionContext context, MarkupViewContext? ctx)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        MarkupViewContext markupViewContext = ctx.Value;
        ClassBuilder classBuilder = CodeBuilder.Create(markupViewContext.Namespace).AddNamespaceImport("Microsoft.UI.Xaml.Data").AddNamespaceImport("System.Runtime.CompilerServices").AddClass(markupViewContext.Name).AddAttribute("CreateNewOnMetadataUpdate");
        context.AddSource(classBuilder.FullyQualifiedName + ".g.cs", classBuilder.Build());
    }

    private MarkupViewContext? ResourceDictionarySyntaxTransform(
      GeneratorSyntaxContext context,
      CancellationToken cancellation)
    {
        ClassDeclarationSyntax declarationSyntax = Unsafe.As<ClassDeclarationSyntax>(context.Node);
        if (Microsoft.CodeAnalysis.CSharp.CSharpExtensions.GetDeclaredSymbol(context.SemanticModel, declarationSyntax, cancellation) is not INamedTypeSymbol declaredSymbol 
            || declaredSymbol.BaseType == null)
            return new MarkupViewContext?();

        if (declaredSymbol.IsAbstract 
            || declaredSymbol.IsStatic 
            || !declaredSymbol.BaseType.IsResourceDictionary()
            )
            return new MarkupViewContext?();

        if (declaredSymbol.DeclaringSyntaxReferences[0].GetSyntax(cancellation) != context.Node)
            return new MarkupViewContext?();

        return ImmutableArrayExtensions.Any(declaredSymbol.GetAttributes(), (Func<AttributeData, bool>)(a =>
         a.AttributeClass is INamedTypeSymbol attributeClass  
            && attributeClass.Name == "CreateNewOnMetadataUpdateAttribute" 
            && attributeClass.GetFullyQualifiedTypeExcludingGlobal() == "System.Runtime.CompilerServices.CreateNewOnMetadataUpdateAttribute"
        )) 
            ? new MarkupViewContext?() 
            : new MarkupViewContext?(new MarkupViewContext(declaredSymbol));
    }

    private static bool ResourceDictionarySyntaxPredicate(
      SyntaxNode node,
      CancellationToken cancellation)
    {
        return node is ClassDeclarationSyntax declarationSyntax 
            && Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.PartialKeyword) 
            && !Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.StaticKeyword) 
            && !Microsoft.CodeAnalysis.CSharpExtensions.Any(declarationSyntax.Modifiers, SyntaxKind.AbstractKeyword) 
            && declarationSyntax.BaseList != null;
    }
}
