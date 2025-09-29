using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers;

[DiagnosticAnalyzer("C#", [])]
internal sealed class MissingGeneratorReferenceAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor _diagnosticDescriptor = new DiagnosticDescriptor("CSM0002", "Missing 'Uno.Extensions.Markup.Generators' package", "For 'GenerateMarkupForAssemblyAttribute' to work, you need to reference 'Uno.Extensions.Markup.Generators' NuGet package", "Correctness", (DiagnosticSeverity)3, true, null, null, Array.Empty<string>());

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(_diagnosticDescriptor);

    public override void Initialize(AnalysisContext context1)
    {
        context1.EnableConcurrentExecution();
        context1.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context1.RegisterCompilationAction(context2 =>
        {
            if (context2.Compilation
                .GetTypeByMetadataName("P42.Uno.Markup.Generator.GenerateMarkupForAssemblyAttribute")
                is not INamedTypeSymbol typeByMetadataName
                || HasGeneratorsReference(context2))
                return;

            foreach (AttributeData attribute in context2.Compilation.Assembly.GetAttributes())
            {
                if (typeByMetadataName.Equals(attribute.AttributeClass, SymbolEqualityComparer.Default))
                    context2.ReportDiagnostic(Diagnostic.Create(_diagnosticDescriptor, CreateLocation(attribute), Array.Empty<object>()));
            }
        });
    }

    private static Location? CreateLocation(AttributeData attribute)
    {
        var applicationSyntaxReference = attribute.ApplicationSyntaxReference;
        return applicationSyntaxReference != null 
            ? Location.Create(applicationSyntaxReference.SyntaxTree, applicationSyntaxReference.Span) 
            : Location.None;
    }

    private static bool HasGeneratorsReference(CompilationAnalysisContext context)
    {
        return context.Options.GetMSBuildPropertyValue("HasMarkupGeneratorsReference") == "true";
    }
}
