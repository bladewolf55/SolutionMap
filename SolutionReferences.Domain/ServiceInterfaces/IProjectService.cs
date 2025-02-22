using SolutionReferences.Domain.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace SolutionReferences.Domain.ServiceInterfaces;

public interface IProjectService
{
    List<Project> GetAngularProjects(Solution solution, string angularFilePath, JsonElement packageJson);
    Project GetAureliaProject(Solution solution, string solutionFilePath, JsonElement packageJson);
    Project GetVisualStudioProject(string filePath);
}