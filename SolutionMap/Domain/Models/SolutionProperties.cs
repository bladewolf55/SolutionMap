namespace SolutionMap.Domain.Models;

public record SolutionProperties
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string SolutionType { get; set; } = string.Empty;
    public string SolutionTypeVersion { get; set; } = string.Empty;
    public string VisualStudioSolutionFileVersion { get; set; } = string.Empty;
    public string VisualStudioFormatVersion { get; set; } = string.Empty;
    public string MinimumVisualStudioVersion { get; set; } = string.Empty;
}
