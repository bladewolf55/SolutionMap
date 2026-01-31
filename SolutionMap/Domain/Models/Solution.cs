namespace SolutionMap.Domain.Models;

public record Solution : SolutionProperties
{
    public virtual List<Project> Projects { get; set; } = null!;
}
