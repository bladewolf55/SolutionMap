using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SolutionReferences
{
    public class ProjectService
    {
        ReferenceService _referenceService;

        public ProjectService()
        {
            _referenceService = new ReferenceService(this);
        }
        public Project ParseVisualStudioProjectFile(string filePath)
        {            
            var xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(filePath);
            var xmlRoot = xmlDocument.DocumentElement;
            var project = new Project();
            project.FilePath = filePath;
            project.Id = xmlRoot.GetXmlPropertyValue("ProjectGuid");
            project.TargetFramework = 
                xmlRoot.GetXmlPropertyValue("TargetFramework")
                ?? xmlRoot.GetXmlPropertyValue("TargetFrameworkVersion");
            project.AssemblyName = xmlRoot.GetXmlPropertyValue("AssemblyName", project.Name);
            project.Name = project.AssemblyName;
            project.RootNamespace = xmlRoot.GetXmlPropertyValue("RootNamespace", project.Name);
            project.PackageId = xmlRoot.GetXmlPropertyValue("Version", "1.0.0");
            project.AssemblyVersion = xmlRoot.GetXmlPropertyValue("AssemblyVersion", "1.0.0.0");
            project.AssemblyFileVersion = xmlRoot.GetXmlPropertyValue("AssemblyFileVersion", "1.0.0.0");

            if (xmlRoot.HasAttribute("Sdk"))
            {
                // Core

            }
            else
            {
                // Framework
                // TODO: Evaluate the .nuspec file

                // Could be using Project References
                var projectReferences = xmlRoot.GetElementsByTagName("ProjectReference").GetEnumerator();
                while (projectReferences.MoveNext())
                {
                    string projectFolderPath = Path.GetDirectoryName(project.FilePath);
                    var element = projectReferences.Current as XmlElement;
                    var reference = _referenceService.ParseVisualStudioProjectReferenceElement(projectFolderPath, element);
                    reference.ParentProject = project;
                    project.References.Add(reference);
                }



                var references = xmlRoot.GetElementsByTagName("Reference");

            }


            return project;
        }



    }
}
