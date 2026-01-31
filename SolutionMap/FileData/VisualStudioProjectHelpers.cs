using SolutionMap.Domain.Models;
using SolutionMap.Domain.Utilities;
using System.Xml;

namespace SolutionMap.FileData;

internal class VisualStudioProjectHelpers
{
    VisualStudioReferenceHelpers referenceHelpers = new();
    public ProjectFile Parse(string filePath, bool skipReferences = false)
    {
        var extension = Path.GetExtension(filePath).ToLower();
        string[] validExtensions = new[] { ".csproj", ".vbproj", ".fsproj" };
        if (!validExtensions.Contains(extension))
        {
            throw new ArgumentException($"Invalid project file extension: {extension}");
        }
        var projectFile = new ProjectFile();
        // File path is unqiue to the project
        projectFile.Id = filePath;
        projectFile.FilePath = filePath;
        projectFile.ProjectType = extension switch
        {
            ".csproj" => "C#",
            ".vbproj" => "VB.NET",
            ".fsproj" => "F#",
            _ => "Unknown"
        };

        var fileName = Path.GetFileNameWithoutExtension(filePath);
        var xmlDocument = new System.Xml.XmlDocument();
        xmlDocument.Load(filePath);
        var xmlRoot = xmlDocument.DocumentElement;
        if (xmlRoot != null)
        {
            projectFile.TargetFramework =
                xmlRoot.GetXmlPropertyValue("TargetFramework")
                ?? xmlRoot.GetXmlPropertyValue("TargetFrameworkVersion");
            if (string.IsNullOrEmpty(projectFile.TargetFramework))
                projectFile.TargetFramework = xmlRoot.GetXmlPropertyValue("TargetFrameworks")?.Split(';').FirstOrDefault() ?? "";
            projectFile.AssemblyName = xmlRoot.GetXmlPropertyValue("AssemblyName", fileName);
            projectFile.RootNamespace = xmlRoot.GetXmlPropertyValue("RootNamespace", projectFile.AssemblyName);
            projectFile.Name = projectFile.AssemblyName;
            projectFile.AssemblyVersion = xmlRoot.GetXmlPropertyValue("AssemblyVersion", "1.0.0.0");
            projectFile.AssemblyFileVersion = xmlRoot.GetXmlPropertyValue("AssemblyFileVersion", "1.0.0.0");
            projectFile.PackageId = xmlRoot.GetXmlPropertyValue("PackageId", projectFile.AssemblyName);
            projectFile.PackageVersion = xmlRoot.GetXmlPropertyValue("Version", projectFile.AssemblyVersion);
        }
        if (!skipReferences)
        {
            // Project References
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var projectReferences = xmlRoot.GetElementsByTagName("ProjectReference");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            foreach (XmlElement projectReference in projectReferences)
            {
                var fileReference = referenceHelpers.ParseProjectReference(projectFile, projectReference);
                projectFile.References.Add(fileReference);
            }

            // Package References
            var packageReferences = xmlRoot.GetElementsByTagName("PackageReference");
            foreach (XmlElement packageReference in packageReferences)
            {
                var fileReference = referenceHelpers.ParsePackageReference(packageReference);
                projectFile.References.Add(fileReference);
            }

            // Legacy (old-style) references
            var legacyReferences = xmlRoot.GetElementsByTagName("Reference");

            foreach (XmlElement legacyReference in legacyReferences)
            {
                var fileReference = referenceHelpers.ParseLegacyReference(legacyReference);
                projectFile.References.Add(fileReference);
            }

            if (!xmlRoot.HasAttribute("Sdk"))
            {
                // Framework
                // TODO: Evaluate the .nuspec file
            }
        }
        return projectFile;
    }

}
