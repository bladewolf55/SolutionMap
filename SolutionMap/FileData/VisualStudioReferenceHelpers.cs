using SolutionMap.Domain.Models;
using SolutionMap.Domain.Utilities;
using System.Xml;

namespace SolutionMap.FileData;

internal class VisualStudioReferenceHelpers
{
    public ProjectFileReference ParseProjectReference(ProjectFile projectFile, XmlElement element)
    {
        var reference = new ProjectFileReference();
        reference.ReferenceType = "Project";
        var projectPath = Path.GetDirectoryName(projectFile.FilePath);
        if (projectPath == null)
        {
            throw new Exception($"Could not determine project path for project file {projectFile.FilePath}");
        }
        reference.FilePath = IOHelpers.CombineToNormalizedPath(projectPath, element.GetAttribute("Include"));
        try
        {
            // parse the project file path
            var parsedProject = new VisualStudioProjectHelpers().Parse(reference.FilePath, skipReferences: true);
            reference.Name = parsedProject.Name;
            reference.Version = parsedProject.AssemblyVersion;
        }
        catch
        {
            // if the project file can't be parsed, use the file name as the reference name and leave the version blank
            reference.Name = Path.GetFileNameWithoutExtension(reference.FilePath);
            reference.Version = "";
        }
        // a project reference is specific to a project, unlike assembly or package references
        // so its unique id must be project-specific as well
        reference.Id = reference.FilePath;
        return reference;
    }

    public ProjectFileReference ParsePackageReference(XmlElement element)
    {
        var reference = new ProjectFileReference();
        reference.ReferenceType = "Package";
        reference.Name = element.GetAttribute("Include");
        reference.Version = element.GetAttribute("Version");
        reference.Id = $"{reference.Name}-{reference.Version}";
        return reference;
    }

    public ProjectFileReference ParseLegacyReference(XmlElement element)
    {
        var reference = new ProjectFileReference();
        var include = element.GetAttribute("Include");

        var includeParts = include.Split(",").Select(a => a.Trim());
        reference.Name = includeParts.First();
        var hintPaths = element.GetElementsByTagName("HintPath");
        bool isLocal = hintPaths.Count > 0;
        if (isLocal)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var hintPath = hintPaths[0].InnerText;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

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
            reference.Id = reference.Name;
        }
        return reference;
    }
}
