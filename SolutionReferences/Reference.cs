using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReferences
{
    public class Reference
    {
        /// <summary>
        /// Assembly, Package, Project, Sdk
        /// </summary>
        public string ReferenceType { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public Project ParentProject { get; set; }
        public Project ProjectReference { get; set; }
    }
}
