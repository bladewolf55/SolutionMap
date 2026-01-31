namespace SolutionMap.FileData;

internal class NodeProjectHelpers
{
    //    public List<ProjectProperties> GetAngularProjects(SolutionProperties solution, string angularFilePath, JsonElement packageJson)
    //    {
    //        var projects = new List<ProjectProperties>();
    //        var angularText = File.ReadAllText(angularFilePath);
    //        var angularJson = JsonDocument.Parse(angularText).RootElement;
    //        var angularProjects = angularJson.GetProperty("projects").EnumerateObject();
    //        var angularRootPath = Path.GetDirectoryName(angularFilePath);

    //        foreach (var angularProject in angularProjects)
    //        {
    //            var properties = angularProject.Value.EnumerateObject();
    //            var project = new ProjectProperties();
    //            var projectRoot = properties.GetJsonEnumeratedValue("root");
    //            project.FilePath = IOHelpers.CombineToNormalizedPath(angularRootPath, projectRoot);
    //            project.Name = angularProject.Name;
    //            project.ProjectType = properties.GetJsonEnumeratedValue("projectType");
    //            project.TargetFramework = solution.SolutionType + solution.SolutionTypeVersion;
    //            project.Id = $"{project.Name}-{projectRoot}";
    //            project.References = _referenceService.ParseNodeReferences(project, packageJson);
    //            project.Solution = solution;
    //            projects.Add(project);
    //        }

    //        return projects;
    //    }

    //    public ProjectProperties GetAureliaProject(SolutionProperties solution, string solutionFilePath, JsonElement packageJson)
    //    {
    //        var project = new ProjectProperties();
    //        project.FilePath = Path.GetDirectoryName(solutionFilePath);
    //        project.Id = solution.Name;
    //        project.Name = solution.Name;
    //        project.AssemblyVersion = packageJson.GetChainedPropertyValue("version");
    //        project.ProjectType = solution.SolutionType;
    //        project.TargetFramework = solution.SolutionType + solution.SolutionTypeVersion;
    //        project.References = _referenceService.ParseNodeReferences(project, packageJson);
    //        project.Solution = solution;
    //        return project;
    //    }
    //}

}
