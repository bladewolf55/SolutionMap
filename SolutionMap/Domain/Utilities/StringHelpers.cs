using System.Text;

namespace SolutionMap.Domain.Utilities;

public static class StringHelpers
{
    public static bool Starts(this string text, string value)
    {
        return text.StartsWith(value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool Has(this string text, string value)
    {
        return text.Contains(value, StringComparison.OrdinalIgnoreCase);
    }

    public static string GetLastSegment(this string text, string delimiter = " ")
    {
        int index = text.LastIndexOf(" ");
        return text.Substring(index).Trim();
    }

    public static (string ProjectId, string ProjectName, string ProjectFilePath) GetProjectParts(this string text)
    {
        var parts = text.Split("=");
        var part1 = parts[0];
        var part2 = parts[1];
        int startIndex = part1.IndexOf("\"") + 1;
        int endIndex = part1.LastIndexOf("\"");
        int length = endIndex - startIndex;
        if (length <= 0) { throw new Exception("Invalid ProjectId part"); }
        string projectId = part1.Substring(startIndex, length);

        var projectParts = part2.Split(",").Select(a => a.Replace("\"", "").Trim()).ToArray();
        string projectName = projectParts[0];
        string projectFilePath = projectParts[1];

        return (projectId, projectName, projectFilePath);
    }


    // https://gunnarpeipman.com/csharp-string-repeat/
    public static string Repeat(this string s, int n)
    {
        return new StringBuilder(s.Length * n)
                    .AppendJoin(s, new string[n + 1])
                    .ToString();
    }
}
