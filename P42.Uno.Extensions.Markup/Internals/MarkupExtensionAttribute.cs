using System;
using System.ComponentModel;

#nullable disable
namespace P42.Uno.Extensions.Markup.Internals;

[EditorBrowsable(EditorBrowsableState.Never)]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class MarkupExtensionAttribute : Attribute
{
}
