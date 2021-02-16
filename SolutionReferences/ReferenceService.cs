using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SolutionReferences
{
    public class ReferenceService
    {
        // Must only be injected, otherwise recursive stack overflow happens.
        ProjectService _projectService;
        public ReferenceService(ProjectService projectService)
        {
            _projectService = projectService;
        }
        public Reference ParseVisualStudioProjectReferenceElement(string projectFolderPath, XmlElement element)
        {
            var reference = new Reference()
            {
                ReferenceType = "Project",
                FilePath = IOHelpers.CombineToNormalizedPath(projectFolderPath, element.GetAttribute("Include")),
            };
            reference.ProjectReference = _projectService.ParseVisualStudioProjectFile(reference.FilePath);
            reference.Name = reference.ProjectReference.Name;

            return reference;
        }
    }
}
