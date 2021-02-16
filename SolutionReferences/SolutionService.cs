using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SolutionReferences
{
    public class SolutionService
    {
        private readonly ProjectService _projectService = new ProjectService();
        public Solution Parse(string filePath)
        {
            var solution = new Solution();

            if (Path.GetExtension(filePath).Equals(".sln", StringComparison.OrdinalIgnoreCase))
            {
                return ParseVisualStudioSolution(filePath);
            }
            if (Path.GetFileName(filePath).Equals("package.json", StringComparison.OrdinalIgnoreCase))
            {
                return ParseNodeSolution(filePath);
            }
            throw new ArgumentException("Solution file not supported");
        }

        private Solution ParseVisualStudioSolution(string filePath)
        {
            Solution solution = new Solution();
            solution.FilePath = filePath;
            string text = File.ReadAllText(filePath);
            var lines = text.Trim().Split(Environment.NewLine);
            foreach (var line in lines)
            {
                // VISUAL STUDIO
                if (line.Starts("Microsoft Visual Studio Solution File"))
                {
                    solution.SolutionType = "Visual Studio";
                    solution.Name = Path.GetFileName(filePath);
                    solution.VisualStudioFormatVersion = line.GetLastSegment();
                }
                if (line.Has("Visual Studio Version")
                    || line.StartsWith("VisualStudioVersion", StringComparison.OrdinalIgnoreCase))
                {
                    solution.VisualStudioSolutionFileVersion = line.GetLastSegment();
                }
                if (line.Starts("MinimumVisualStudioVersion"))
                {
                    solution.MinimumVisualStudioVersion = line.GetLastSegment();
                }
                if (line.Starts("Project"))
                {
                    var solutionFolder = Path.GetDirectoryName(solution.FilePath);
                    var projectParts = line.GetProjectParts();
                    var projectFilePath = IOHelpers.CombineToNormalizedPath(solutionFolder, projectParts.ProjectFilePath);
                    var project = _projectService.ParseVisualStudioProjectFile(projectFilePath);
                    project.Solution = solution;
                    solution.Projects.Add(project);
                }

            }
            return solution;
        }

        private Solution ParseNodeSolution(string filePath)
        {
            var solution = new Solution();
            solution.FilePath = filePath;
            var packageText = File.ReadAllText(filePath);
            try
            {
                var packageJson = JsonDocument.Parse(packageText).RootElement;
                solution.Name = packageJson.GetChainedPropertyValue("name");
                if (packageText.Contains("aurelia")) { 
                    solution.SolutionType = "Aurelia";
                    solution.SolutionTypeVersion =
                        packageJson.GetChainedPropertyValue("devDependencies:aurelia-cli")
                        ?? packageJson.GetChainedPropertyValue("dependencies:aurelia-cli")
                        ;
                    // Single Project
                    var project = new Project()
                    {
                        FilePath = Path.GetDirectoryName( filePath),
                        Id = solution.Name,
                        Name = solution.Name,
                        AssemblyVersion = packageJson.GetChainedPropertyValue("version"),
                        ProjectType = solution.SolutionType,
                        TargetFramework = solution.SolutionType + solution.SolutionTypeVersion,
                        Solution = solution
                    };
                    solution.Projects.Add(project);
                }
                else if (packageText.Contains("angular")) {
                    solution.SolutionType = "Angular";
                    solution.SolutionTypeVersion = 
                        packageJson.GetChainedPropertyValue(@"devDependencies:@angular/cli")
                        ?? packageJson.GetChainedPropertyValue(@"dependencies:@angular/cli")
                        ?? packageJson.GetChainedPropertyValue(@"devDependencies:@angular/core")
                        ?? packageJson.GetChainedPropertyValue(@"dependencies:@angular/core")
                        ;
                    var workspaceFolderPath = Path.GetDirectoryName(filePath);
                    var angularFilePath = IOHelpers.CombineToNormalizedPath(workspaceFolderPath, "angular.json");
                    var angularText = File.ReadAllText(angularFilePath);
                    var angularJson = JsonDocument.Parse(angularText).RootElement;
                    var angularProjects = angularJson.GetProperty("projects").EnumerateObject();
                    var angularProjectRoot = Path.GetDirectoryName(angularFilePath);
                    foreach (var angularProject in angularProjects)
                    {
                        var properties = angularProject.Value.EnumerateObject();
                        var project = new Project()
                        {
                            FilePath = IOHelpers.CombineToNormalizedPath(angularProjectRoot, 
                                properties.GetJsonEnumeratedValue("root")
                                .Replace(@"/",@"\")),
                            Id = angularProject.Name,
                            Name = angularProject.Name,
                            ProjectType = properties.GetJsonEnumeratedValue("projectType"),
                            TargetFramework = solution.SolutionType + solution.SolutionTypeVersion,
                            Solution = solution
                        };
                        solution.Projects.Add(project);
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error parsing node solution: {ex.GetBaseException().Message}");
            }

            return solution;
        }

    }
}
