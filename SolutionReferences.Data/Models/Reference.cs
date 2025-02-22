using System.Collections.Generic;

namespace SolutionReferences.Data.Models;

public class Reference
{
    public string ReferenceId { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string ReferenceType { get; set; }
    public string FilePath { get; set; }

    // Navigation
    public List<Project> Projects { get; set; } = new List<Project>();
    public Project ReferencedByProject { get; set; }

}
