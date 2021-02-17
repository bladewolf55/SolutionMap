using SolutionReferences.Domain.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;

namespace SolutionReferences.Domain.ServiceInterfaces
{
    public interface IReferenceService
    {
        List<Reference> ParseNodeReferences(Project project, JsonElement packageJson);
        Reference ParseVisualStudioProjectReferenceElement(string projectFolderPath, XmlElement element);
        Reference ParseVisualStudioPackageReferenceElement(XmlElement element);
        Reference ParseVisualStudioReferenceElement(XmlElement element);
    }
}