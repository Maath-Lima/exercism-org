using System;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (String.IsNullOrEmpty(identifier))
            return String.Empty;
        
        var identifierFormat = identifier.Replace(" ", "_").Replace("\0", "CTRL");

        var identifierRemovedKebabCase = Regex.Replace(identifierFormat, @"(-.)", m => m.Groups[0].Value.Replace("-", "").ToUpper());
        var identifierOnlyLetters = Regex.Replace(identifierRemovedKebabCase, @"[0-9άαβγδέεζήηίΐϊιλμνόορύΰϋυώωτ?]|[^\u1F600-\u1F6FF\s]", "");

        return identifierOnlyLetters;
    }
}
