using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using SolutionReferences.Domain.Models;
using SolutionReferences.Domain.Utilities;
using SolutionReferences.Domain.ServiceInterfaces;

namespace SolutionReferences.Services
{
    public class ProjectService : IProjectService
    {
        IReferenceService _referenceService;

        public ProjectService(IReferenceService referenceService = null)
        {
            _referenceService = referenceService ?? new ReferenceService(this);
        }

        public Project GetVisualStudioProject(string filePath)
        {
            var xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(filePath);
            var xmlRoot = xmlDocument.DocumentElement;
            var project = new Project();
            project.FilePath = filePath;
            project.TargetFramework =
                xmlRoot.GetXmlPropertyValue("TargetFramework")
                ?? xmlRoot.GetXmlPropertyValue("TargetFrameworkVersion");
            project.AssemblyName = xmlRoot.GetXmlPropertyValue("AssemblyName", project.Name);
            project.Name = project.AssemblyName;
            project.RootNamespace = xmlRoot.GetXmlPropertyValue("RootNamespace", project.Name);
            project.PackageId = xmlRoot.GetXmlPropertyValue("Version", "1.0.0");
            project.AssemblyVersion = xmlRoot.GetXmlPropertyValue("AssemblyVersion", "1.0.0.0");
            project.AssemblyFileVersion = xmlRoot.GetXmlPropertyValue("AssemblyFileVersion", "1.0.0.0");
            project.Id = $"{ project.Name}-{project.AssemblyVersion}";

            if (xmlRoot.HasAttribute("Sdk"))
            {
                // Core

            }
            else
            {
                // Framework
                // TODO: Evaluate the .nuspec file

                // Project References
                var projectReferences = xmlRoot.GetElementsByTagName("ProjectReference");
                foreach (XmlElement projectReference in projectReferences)
                {
                    string projectFolderPath = Path.GetDirectoryName(project.FilePath);
                    var reference = _referenceService
                        .ParseVisualStudioProjectReferenceElement(projectFolderPath, projectReference);
                    reference.ParentProject = project;
                    project.References.Add(reference);

                }

                // Other references
                projectReferences = xmlRoot.GetElementsByTagName("Reference");

                foreach (XmlElement projectReference in projectReferences)
                {
                    var reference = _referenceService
                        .ParseVisualStudioReferenceElement(projectReference);
                    reference.ParentProject = project;
                    project.References.Add(reference);
                }
            }
            return project;
        }

        public List<Project> GetAngularProjects(Solution solution, string angularFilePath, JsonElement packageJson)
        {
            var projects = new List<Project>();
            var angularText = File.ReadAllText(angularFilePath);
            var angularJson = JsonDocument.Parse(angularText).RootElement;
            var angularProjects = angularJson.GetProperty("projects").EnumerateObject();
            var angularRootPath = Path.GetDirectoryName(angularFilePath);

            foreach (var angularProject in angularProjects)
            {
                var properties = angularProject.Value.EnumerateObject();
                var project = new Project();
                var projectRoot = properties.GetJsonEnumeratedValue("root");
                project.FilePath = IOHelpers.CombineToNormalizedPath(angularRootPath, projectRoot);
                project.Name = angularProject.Name;
                project.ProjectType = properties.GetJsonEnumeratedValue("projectType");
                project.TargetFramework = solution.SolutionType + solution.SolutionTypeVersion;
                project.Id = $"{project.Name}-{projectRoot}";
                project.References = _referenceService.ParseNodeReferences(project, packageJson);
                project.Solution = solution;
                projects.Add(project);
            }

            return projects;
        }

        public Project GetAureliaProject(Solution solution, string solutionFilePath, JsonElement packageJson)
        {
            var project = new Project();
            project.FilePath = Path.GetDirectoryName(solutionFilePath);
            project.Id = solution.Name;
            project.Name = solution.Name;
            project.AssemblyVersion = packageJson.GetChainedPropertyValue("version");
            project.ProjectType = solution.SolutionType;
            project.TargetFramework = solution.SolutionType + solution.SolutionTypeVersion;
            project.References = _referenceService.ParseNodeReferences(project, packageJson);
            project.Solution = solution;
            return project;
        }
    }
}
