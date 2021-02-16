using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using SolutionReferences.Domain.Models;
using SolutionReferences.Domain.Utilities;
using SolutionReferences.Domain.ServiceInterfaces;


namespace SolutionReferences.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly IProjectService _projectService;

        public SolutionService(IProjectService projectService = null)
        {
            _projectService = projectService ?? new ProjectService();
        }


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

        public Solution ParseVisualStudioSolution(string filePath)
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
                    solution.Id = solution.Name;
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
                    var project = _projectService.GetVisualStudioProject(projectFilePath);
                    project.Solution = solution;
                    solution.Projects.Add(project);
                }

            }
            return solution;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <remarks>
        /// There's no easy way to determine which references
        /// a project uses, so each project shows all package.json references.
        /// </remarks>
        public Solution ParseNodeSolution(string filePath)
        {
            var solution = new Solution();
            solution.FilePath = filePath;
            var packageText = File.ReadAllText(filePath);
            try
            {
                var packageJson = JsonDocument.Parse(packageText).RootElement;
                solution.Name = packageJson.GetChainedPropertyValue("name");
                solution.Id = solution.Name;
                // Aurelia
                if (packageText.Contains("aurelia"))
                {
                    solution.SolutionType = "Aurelia";
                    solution.SolutionTypeVersion =
                        packageJson.GetChainedPropertyValue("devDependencies:aurelia-cli")
                        ?? packageJson.GetChainedPropertyValue("dependencies:aurelia-cli")
                        ;
                    // Single Project
                    var project = _projectService
                        .GetAureliaProject(solution, solution.FilePath, packageJson);
                    solution.Projects.Add(project);
                }
                // Angular
                else if (packageText.Contains("angular"))
                {
                    solution.SolutionType = "Angular";
                    solution.SolutionTypeVersion =
                        packageJson.GetChainedPropertyValue(@"devDependencies:@angular/cli")
                        ?? packageJson.GetChainedPropertyValue(@"dependencies:@angular/cli")
                        ?? packageJson.GetChainedPropertyValue(@"devDependencies:@angular/core")
                        ?? packageJson.GetChainedPropertyValue(@"dependencies:@angular/core")
                        ;
                    var workspaceFolderPath = Path.GetDirectoryName(filePath);
                    var angularFilePath = IOHelpers.CombineToNormalizedPath(workspaceFolderPath, "angular.json");
                    solution.Projects = _projectService.GetAngularProjects(solution, angularFilePath, packageJson);
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
