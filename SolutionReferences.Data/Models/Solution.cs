using System.Collections.Generic;

namespace SolutionReferences.Data.Models;

public class Solution
{
    public string SolutionId { get; set; }
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string SolutionType { get; set; }
    public string SolutionTypeVersion { get; set; }
    public string VisualStudioSolutionFileVersion { get; set; }
    public string VisualStudioFormatVersion { get; set; }
    public string MinimumVisualStudioVersion { get; set; }

    // Navigation
    public List<Project> Projects { get; set; } = new List<Project>();

}
