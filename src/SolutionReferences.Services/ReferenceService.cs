using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml;
using SolutionReferences.Domain.Models;
using SolutionReferences.Domain.Utilities;
using SolutionReferences.Domain.ServiceInterfaces;


namespace SolutionReferences.Services
{
    public class ReferenceService : IReferenceService
    {
        // Must only be injected, otherwise recursive stack overflow happens.
        IProjectService _projectService;
        public ReferenceService(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public Reference ParseVisualStudioProjectReferenceElement(string projectFolderPath, XmlElement element)
        {
            var reference = new Reference();
            reference.ReferenceType = "Project";
            reference.FilePath = IOHelpers.CombineToNormalizedPath(projectFolderPath, element.GetAttribute("Include"));
            reference.ProjectReference = _projectService.GetVisualStudioProject(reference.FilePath);
            reference.Name = reference.ProjectReference.Name;
            reference.Version = reference.ProjectReference.AssemblyVersion;
            reference.Id = $"{reference.Name}-{reference.Version}";

            return reference;
        }

        public Reference ParseVisualStudioReferenceElement(XmlElement element)
        {
            var reference = new Reference();
            var include = element.GetAttribute("Include");
            var includeParts = include.Split(",").Select(a => a.Trim());
            reference.Name = includeParts.First();
            bool isLocal = element.GetElementsByTagName("HintPath").Count > 0;
            if (isLocal)
            {
                var hintPath = element.GetElementsByTagName("HintPath")[0].InnerText;
                if (hintPath.Contains(@"\packages\"))
                {
                    reference.ReferenceType = "Package";
                    int packageVersionStart = hintPath.IndexOf("packages") + 10;
                    int packageVersionEnd = hintPath.IndexOf(@"\", packageVersionStart);
                    var packageVersionParts = hintPath.Substring(packageVersionStart, packageVersionEnd - packageVersionStart).Split(".");
                    reference.Version = string.Join(".", packageVersionParts.Skip(packageVersionParts.Count() - 3));
                }
                else
                {
                    reference.ReferenceType = "Assembly";
                    if (include.Contains("Version"))
                    {
                        var versionPart = includeParts.Where(a => a.StartsWith("Version")).Single();
                        reference.Version = versionPart.Substring(7);
                    }
                }
                reference.Id = $"{reference.Name}-{reference.Version}";
            }
            else
            {
                reference.ReferenceType = "System";
            }
            return reference;
        }

        public List<Reference> ParseNodeReferences(Project project, JsonElement packageJson)
        {
            var references = new List<Reference>();
            var dependencies = packageJson.GetProperty("dependencies").EnumerateObject();
            foreach (var dependency in dependencies)
            {
                var reference = new Reference();
                reference.Name = dependency.Name;
                reference.Version = dependency.Value.ToString();
                reference.ReferenceType = "Package";
                reference.Id = $"{reference.Name}-{reference.Version}";
                reference.ParentProject = project;
                references.Add(reference);
            }

            var devDependencies = packageJson.GetProperty("devDependencies").EnumerateObject();
            foreach (var dependency in dependencies)
            {
                var reference = new Reference();
                reference.Name = dependency.Name;
                reference.Version = dependency.Value.ToString();
                reference.ReferenceType = "DevPackage";
                reference.Id = $"{reference.Name}-{reference.Version}";
                reference.ParentProject = project;
                references.Add(reference);
            }
            return references;
        }
    }
}
