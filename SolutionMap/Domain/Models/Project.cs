namespace SolutionMap.Domain.Models;

public record Project : ProjectProperties
{
    public virtual List<Solution> Solutions { get; set; } = null!;
    public virtual List<Reference> References { get; set; } = null!;

    public List<Reference> ProjectReferences => References.Where(a => a.ReferenceType == "Project").ToList();
    public List<Reference> PackageReferences => References.Where(a => a.ReferenceType == "Package").ToList();
    public List<Reference> SystemReferences => References.Where(a => a.ReferenceType == "System").ToList();
}