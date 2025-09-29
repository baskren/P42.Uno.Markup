using Microsoft.CodeAnalysis.CSharp;
using System.Globalization;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensions;

public static class StringExtensions
{
    public static string Camelcase(this string str)
        => str.Length <= 1 
            ? str.ToLowerInvariant() 
            : char.ToLower(str[0], CultureInfo.InvariantCulture).ToString() + str.Substring(1);
    

    public static string EscapeIdentifier(this string identifier)
        => SyntaxFacts.GetKeywordKind(identifier) != 0 
            ? "@" + identifier 
            : identifier;
    
}
