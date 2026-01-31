namespace SolutionMap.Domain.Models;

public record ReferenceProperties
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Version { get; set; } = string.Empty;
    public string ReferenceType { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
}
