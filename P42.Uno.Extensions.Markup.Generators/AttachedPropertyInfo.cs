using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace P42.Uno.Extensions.Markup.Generators;

internal partial record AttachedPropertyInfo(string Name, string PropertyTypeFullyQualified, bool PropertyTypeIsNullableValueType, string DependencyProperty, GenerationTypeInfo GenerationTypeInfo) : BaseModel(GenerationTypeInfo)
{

}
