namespace SolutionMap.Domain.Models;

public record Reference : ReferenceProperties
{
    public virtual List<Project> Projects { get; set; } = null!;
}
