using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;
using P42.Uno.Extensions.Markup.Analyzers.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers;

[DiagnosticAnalyzer("C#", [])]
internal sealed class UseTheLambdaSyntaxAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor _diagnosticDescriptor = new DiagnosticDescriptor("CSM0003", "Use lambda syntax", "The DataContext parameter '{0}' should not be directly referenced. Use the lambda syntax of '{1}(() => {0}.YourProperty)' instead.", "Correctness", (DiagnosticSeverity)3, true, null, null, Array.Empty<string>());

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(_diagnosticDescriptor);

    public override void Initialize(AnalysisContext context1)
    {
        context1.EnableConcurrentExecution();
        context1.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context1.RegisterCompilationStartAction((Action<CompilationStartAnalysisContext>)(context9 =>
        {
            if (context9.Compilation.GetTypeByMetadataName("System.Action`2") is not INamedTypeSymbol action2)
                return;

            context9.RegisterOperationBlockStartAction(context10 =>
            {
                var lambdaDataContextParameters = new ConcurrentBag<IParameterSymbol>();
                var potentiallyWrongParameterReferences = new ConcurrentBag<IParameterReferenceOperation>();

                context10.RegisterOperationAction(context6 =>
                {
                    IAnonymousFunctionOperation operation = (IAnonymousFunctionOperation)context6.Operation;
                    if (operation.Parent is not IDelegateCreationOperation parent3
                        || parent3.Parent is not IArgumentOperation parent4
                        || parent4.Parameter == null)
                        return;

                    int fromActionParameter = TryGetDataContextParameterIndexFromActionParameter(parent4.Parameter, action2);
                    if (fromActionParameter < 0
                        || fromActionParameter >= operation.Symbol.Parameters.Length)
                        return;

                    lambdaDataContextParameters.Add(operation.Symbol.Parameters[fromActionParameter]);
                }, new OperationKind[1] { OperationKind.AnonymousFunction });

                context10.RegisterOperationAction(context7 =>
                {
                    var operation = (IParameterReferenceOperation)context7.Operation;
                    bool flag3 = operation.Parameter.ContainingSymbol is IMethodSymbol containingSymbol2
                        && containingSymbol2.MethodKind == MethodKind.LambdaMethod;

                    if (flag3)
                    {
                        var kind = operation.Parent?.Kind;
                        bool flag4;
                        if (kind.HasValue)
                        {
                            var valueOrDefault = kind.GetValueOrDefault();
                            if (valueOrDefault != OperationKind.ArrayElementReference)
                            {
                                switch (valueOrDefault)
                                {
                                    case OperationKind.FieldReference:
                                    case OperationKind.PropertyReference:
                                    case OperationKind.Unary:
                                        break;
                                    default:
                                        goto label_6;
                                }
                            }
                            flag4 = true;
                            goto label_7;
                        }
                    label_6:
                        flag4 = false;
                    label_7:
                        flag3 = flag4;
                    }

                    if (!flag3)
                        return;

                    potentiallyWrongParameterReferences.Add(operation);

                }, new OperationKind[1] { OperationKind.ParameterReference });

                context10.RegisterOperationBlockEndAction(context8 =>
                {
                    foreach (IParameterReferenceOperation operation in potentiallyWrongParameterReferences)
                    {
                        if (lambdaDataContextParameters.Contains(operation.Parameter, SymbolEqualityComparer.Default) 
                                && ((IOperation)operation).FindFirstAncestor((Func<IOperation, bool>)(op =>
                        {
                            return op switch
                            {
                                IAnonymousFunctionOperation _ => true,
                                IInvocationOperation iInvocationOperation2 => HasLambdaOverload(iInvocationOperation2.TargetMethod),
                                _ => false,
                            };
                        })) is IInvocationOperation firstAncestor2)
                            context8.ReportDiagnostic(Diagnostic.Create(_diagnosticDescriptor, operation.Syntax.GetLocation(),
                            [
                              operation.Parameter.Name,
                              firstAncestor2.TargetMethod.Name
                            ]));
                    }
                });
            
            });
        }));
    }

    private static bool HasLambdaOverload(IMethodSymbol method)
    {
        if (IsLambdaOverload(method))
            return false;
        foreach (ISymbol member in method.ContainingType.GetMembers(method.Name))
        {
            if (member is IMethodSymbol method1 && IsLambdaOverload(method1))
                return true;
        }
        return false;
    }

    private static bool IsLambdaOverload(IMethodSymbol method)
    => method.Parameters.Length == 3 
        && method.Parameters[1].Name == "propertyBinding" 
        && method.Parameters[2].Name == "propertyBindingExpression";
    

    private static int TryGetDataContextParameterIndexFromActionParameter(
      IParameterSymbol parameter,
      ISymbol action2)
    {
        if (!parameter.Type.OriginalDefinition.Equals(action2, SymbolEqualityComparer.Default))
            return -1;

        IMethodSymbol containingSymbol = (IMethodSymbol)parameter.ContainingSymbol;
        if (containingSymbol.Name == "ItemTemplateSelector" 
            && containingSymbol.Arity == 1 
            && parameter.Ordinal == 1)
            return 0;

        return containingSymbol.Name == "DataContext" 
            && (
                containingSymbol.Arity == 1 && parameter.Ordinal == 1 
                || containingSymbol.Arity == 2 && parameter.Ordinal == 2
                ) 
                ? 1 
                : -1;
    }
}
