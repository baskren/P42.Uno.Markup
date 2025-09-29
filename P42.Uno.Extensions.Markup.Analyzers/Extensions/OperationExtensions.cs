using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using System;

namespace P42.Uno.Extensions.Markup.Analyzers.Extensions;

#nullable enable

internal static class OperationExtensions
{
    public static IOperation? FindFirstAncestor(
      this IOperation operation,
      Func<IOperation, bool> predicate)
    {
        for (var parent = operation.Parent; parent != null; parent = parent.Parent)
        {
            if (predicate(parent))
                return parent;
        }
        return null;
    }
}
