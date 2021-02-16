using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReferences
{
    public class Solution
    {
        public string SolutionType { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string VisualStudioSolutionFileVersion { get; set; }
        public string VisualStudioFormatVersion { get; set; }
        public string MinimumVisualStudioVersion { get; set; }
        public string SolutionTypeVersion { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();

    }
}
