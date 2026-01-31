namespace SolutionMap.Domain.Models
{
    public record SolutionFile: SolutionProperties
    {
        public List<ProjectFile> ProjectFiles { get; set; } = new();
    }
}
