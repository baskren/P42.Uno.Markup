using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Immutable;
using System.Linq;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers;

[DiagnosticAnalyzer("C#", [])]
public sealed class UseTheNameSyntaxAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor("CSM0004", "Use .Name instead of .Assign", "Use .Name(out var name) instead of .Assign(out var name)", "Usage", (DiagnosticSeverity)2, true, "The 'Assign' extension method isn't recommended for framework elements. Instead, consider using the 'Name' extension method.", (string)null, Array.Empty<string>());

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create<DiagnosticDescriptor>(UseTheNameSyntaxAnalyzer.Rule);
    

    public override void Initialize(AnalysisContext context1)
    {
        context1.EnableConcurrentExecution();
        context1.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context1.RegisterCompilationStartAction((Action<CompilationStartAnalysisContext>)(context3 =>
        {
            if (context3.Compilation.GetTypeByMetadataName("Microsoft.UI.Xaml.FrameworkElement") is not INamedTypeSymbol frameworkElementType)
                return;

            context3.RegisterOperationAction(context4 =>
            {
                var operation = (IInvocationOperation)context4.Operation;
                var receiverType = GetReceiverType(operation);
                if (operation.TargetMethod.Name != "Assign" 
                    || receiverType == null 
                    || !receiverType.IsTypeOrDerivesFromType((ITypeSymbol)frameworkElementType)
                    )
                    return;

                context4.ReportDiagnostic(Diagnostic.Create(Rule, operation.Syntax.GetLocation(), Array.Empty<object>()));
            }, new OperationKind[1] { OperationKind.Invocation });
        }));
    }

    private static ITypeSymbol? GetReceiverType(IInvocationOperation invocation)
    {
        if (invocation.Instance != null)
            return invocation.Instance.Type;

        if (!invocation.TargetMethod.IsExtensionMethod || invocation.TargetMethod.Parameters.IsEmpty)
            return null;

        return invocation.Arguments.FirstOrDefault()?.Value.Type;
    }
}
