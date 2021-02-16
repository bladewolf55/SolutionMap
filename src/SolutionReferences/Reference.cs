using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReferences
{
    public class Reference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        /// <summary>
        /// System, Assembly, Package, Project, Sdk, DevPackage
        /// System references have no version; they're likely in the GAC
        /// DevPackage is only used in Node projects
        /// </summary>
        public string ReferenceType { get; set; }
        public string FilePath { get; set; }
        public Project ParentProject { get; set; }
        public Project ProjectReference { get; set; }
    }
}
