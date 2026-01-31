namespace SolutionMap.FileData;

internal class NodeSolutionHelpers
{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="filePath"></param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// There's no easy way to determine which references
    //    /// a project uses, so each project shows all package.json references.
    //    /// </remarks>
    //    public SolutionProperties ParseNodeSolution(string filePath)
    //    {
    //        var solution = new SolutionProperties();
    //        solution.FilePath = filePath;
    //        var packageText = File.ReadAllText(filePath);
    //        try
    //        {
    //            var packageJson = JsonDocument.Parse(packageText).RootElement;
    //            solution.Name = packageJson.GetChainedPropertyValue("name");
    //            solution.Id = solution.Name;
    //            // Aurelia
    //            if (packageText.Contains("aurelia"))
    //            {
    //                solution.SolutionType = "Aurelia";
    //                solution.SolutionTypeVersion =
    //                    packageJson.GetChainedPropertyValue("devDependencies:aurelia-cli")
    //                    ?? packageJson.GetChainedPropertyValue("dependencies:aurelia-cli")
    //                    ;
    //                // Single Project
    //                var project = _projectService
    //                    .GetAureliaProject(solution, solution.FilePath, packageJson);
    //                solution.Projects.Add(project);
    //            }
    //            // Angular
    //            else if (packageText.Contains("angular"))
    //            {
    //                solution.SolutionType = "Angular";
    //                solution.SolutionTypeVersion =
    //                    packageJson.GetChainedPropertyValue(@"devDependencies:@angular/cli")
    //                    ?? packageJson.GetChainedPropertyValue(@"dependencies:@angular/cli")
    //                    ?? packageJson.GetChainedPropertyValue(@"devDependencies:@angular/core")
    //                    ?? packageJson.GetChainedPropertyValue(@"dependencies:@angular/core")
    //                    ;
    //                var workspaceFolderPath = Path.GetDirectoryName(filePath);
    //                var angularFilePath = IOHelpers.CombineToNormalizedPath(workspaceFolderPath, "angular.json");
    //                solution.Projects = _projectService.GetAngularProjects(solution, angularFilePath, packageJson);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception($"Error parsing node solution: {ex.GetBaseException().Message}");
    //        }

    //        return solution;
    //    }

}
