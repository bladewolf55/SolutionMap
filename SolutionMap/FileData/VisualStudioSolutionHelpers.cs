using SolutionMap.Domain.Models;
using SolutionMap.Domain.Utilities;

namespace SolutionMap.FileData;

internal class VisualStudioSolutionHelpers
{
    VisualStudioProjectHelpers projectHelpers = new();

    public SolutionFile Parse(string filePath)
    {
        string[] validExtensions = { ".sln", ".slnx" };
        string extension = Path.GetExtension(filePath).ToLower() ?? "";
        if (!validExtensions.Contains(extension))
        {
            throw new ArgumentException("The specified file is not a Visual Studio solution file.", nameof(filePath));
        }

        // TODO: Implement .slnx
        if (extension == ".slnx")
        {
            throw new NotImplementedException(".slnx solution files are not yet supported.");
        }

        SolutionFile solutionFile = new SolutionFile();

        solutionFile.SolutionType = "Visual Studio";
        // File path is unique to solution
        solutionFile.Id = filePath;
        solutionFile.FilePath = filePath;
        solutionFile.Name = Path.GetFileName(filePath);

        string text = File.ReadAllText(filePath);
        var lines = text.Trim().Split(Environment.NewLine);
        foreach (var line in lines)
        {
            if (line.Starts("Microsoft Visual Studio Solution File"))
            {
                solutionFile.VisualStudioFormatVersion = line.GetLastSegment();
            }
            if (line.Has("Visual Studio Version")
                || line.StartsWith("VisualStudioVersion", StringComparison.OrdinalIgnoreCase))
            {
                solutionFile.VisualStudioSolutionFileVersion = line.GetLastSegment();
            }
            if (line.Starts("MinimumVisualStudioVersion"))
            {
                solutionFile.MinimumVisualStudioVersion = line.GetLastSegment();
            }
            if (line.Starts("Project"))
            {
                var solutionFolder = Path.GetDirectoryName(solutionFile.FilePath);
                if (solutionFolder == null)
                {
                    throw new Exception("Could not determine solution folder from solution file path.");
                }
                var projectParts = line.GetProjectParts();
                var projectFilePath = IOHelpers.CombineToNormalizedPath(solutionFolder, projectParts.ProjectFilePath);
                try
                {
                    var projectFile = projectHelpers.Parse(projectFilePath);
                    solutionFile.ProjectFiles.Add(projectFile);
                }
                catch 
                {
                    // TODO: Raise event
                }
            }
        }
        return solutionFile;

    }
}
