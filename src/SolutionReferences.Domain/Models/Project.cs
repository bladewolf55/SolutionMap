using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReferences.Domain.Models
{
    public class Project
    {
        public string Id { get; set; } // Name + Version
        public string Name { get; set; }
        public string AssemblyVersion { get; set; } // default: 1.0.0.0
        public string FilePath { get; set; }
        public string ProjectType { get; set; }
        public string AssemblyName { get; set; }
        public string RootNamespace { get; set; }
        public string TargetFramework { get; set; }
        public string PackageId { get; set; } // default: Project Name
        public string PackageVersion { get; set; } // default: 1.0.0
        public string AssemblyFileVersion { get; set; } // default: 1.0.0.0
        public string InformationalVersion => PackageVersion;
        public Solution Solution { get; set; }
        public List<Reference> References { get; set; } = new List<Reference>();
    }
}
