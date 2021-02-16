using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReferences.Data.Models
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string AssemblyVersion { get; set; }
        public string FilePath { get; set; }
        public string ProjectType { get; set; }
        public string AssemblyName { get; set; }
        public string RootNamespace { get; set; }
        public string TargetFramework { get; set; }
        public string PackageId { get; set; }
        public string PackageVersion { get; set; }
        public string AssemblyFileVersion { get; set; }
        public string InformationalVersion => PackageVersion;
        
        // Navigation
        public List<Solution> Solutions { get; set; } = new List<Solution>();
        public List<Reference> References { get; set; } = new List<Reference>();
    }
}

