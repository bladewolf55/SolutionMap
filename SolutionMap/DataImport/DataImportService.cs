using SolutionMap.Database;
using SolutionMap.Domain.Models;
using SolutionMap.Domain.ServiceInterfaces;
using SolutionMap.FileData;
using System.Text;

namespace SolutionMap.DataImport;

public class DataImportService : IDataImportService
{

    public event EventHandler<ImportStatusEventArgs> ImportStatus = null!;

    public void OnImportStatus(ImportStatusEventArgs e) => ImportStatus?.Invoke(this, e);

    private void SendStatus(string message)
    {
        message = $"{DateTime.Now.ToString("HH:mm:ss.fff")} {message}";
        OnImportStatus(new ImportStatusEventArgs() { Message = message });
    }

    public void ImportVisualBasicSolutions(string sqliteFilePath, string solutionsPath)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(sqliteFilePath) ?? throw new InvalidOperationException("Invalid database file path"));

        // Database
        var db = new SolutionMapDb($"Data Source={sqliteFilePath}");

        SendStatus($"Deleting and recreating database file at {sqliteFilePath}");
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        //Files
        var service = new SolutionFileService();
        var solutionFilePaths = Directory.GetFiles(solutionsPath, "*.sln", SearchOption.AllDirectories);

        // Import
        SendStatus($"Importing solutions from {solutionsPath}");

        var solutionFiles = solutionFilePaths.Select(filePath => service.ParseVisualStudioSolution(filePath))
            .ToList();

        SendStatus($"Mapping to data objects");

        var solutions = solutionFiles.Select(solutionFile => new Solution()
        {
            Id = solutionFile.Id,
            FilePath = solutionFile.FilePath,
            MinimumVisualStudioVersion = solutionFile.MinimumVisualStudioVersion,
            Name = solutionFile.Name,
            SolutionType = solutionFile.SolutionType,
            SolutionTypeVersion = solutionFile.SolutionTypeVersion,
            VisualStudioFormatVersion = solutionFile.VisualStudioFormatVersion,
            VisualStudioSolutionFileVersion = solutionFile.VisualStudioSolutionFileVersion,
        }).ToList();

        var projectFiles = solutionFiles.SelectMany(sln => sln.ProjectFiles).ToList();

        var projects = projectFiles.Select(projectFile => new Project()
        {
            Id = projectFile.Id,
            AssemblyFileVersion = projectFile.AssemblyFileVersion,
            AssemblyName = projectFile.AssemblyName,
            AssemblyVersion = projectFile.AssemblyVersion,
            FilePath = projectFile.FilePath,
            Name = projectFile.Name,
            PackageId = projectFile.PackageId,
            PackageVersion = projectFile.PackageVersion,
            ProjectType = projectFile.ProjectType,
            RootNamespace = projectFile.RootNamespace,
            TargetFramework = projectFile.TargetFramework,
        }).Distinct().ToList();

        foreach (var solutionFile in solutionFiles)
        {
            var solution = solutions.Single(a => a.Id == solutionFile.Id);
            solution.Projects = projects.Where(a =>
                solutionFile.ProjectFiles.Select(b => b.Id)
                .Contains(a.Id)
                ).ToList();
        }

        var references = projectFiles.SelectMany(a => a.References).Select(referenceFile => new Reference()
        {
            Id = referenceFile.Id,
            FilePath = referenceFile.FilePath,
            Name = referenceFile.Name,
            ReferenceType = referenceFile.ReferenceType,
            Version = referenceFile.Version

        }).Distinct().ToList();

        foreach (var projectFile in projectFiles)
        {
            var project = projects.Single(a => a.Id == projectFile.Id);
            project.References = references.Where(a =>
                projectFile.References.Select(b => b.Id)
                .Contains(a.Id)
                ).ToList();
        }

        SendStatus($"Adding to data context");
        db.Solutions.AddRange(solutions);
        db.Projects.AddRange(projects);
        db.References.AddRange(references);
        SendStatus($"Saving to database");
        db.SaveChanges();

        // report
        StringBuilder completedMessage = new();
        int padLeft = 5;
        completedMessage.AppendLine($"Import complete");
        completedMessage.AppendLine($"Solutions:  {db.Solutions.Count().ToString().PadLeft(padLeft)}");
        completedMessage.AppendLine($"Projects:   {db.Projects.Count().ToString().PadLeft(padLeft)}");
        completedMessage.AppendLine($"References: {db.References.Count().ToString().PadLeft(padLeft)}");

        SendStatus("\n" + completedMessage.ToString());


        // smoke test
        // internal use only
        StringBuilder smokeTest = new();
        var packageReferences = db.Projects.Select(a => new {
            a.Name,
            a.PackageReferences
        }).ToList();
        foreach (var pr in packageReferences)
        {
            smokeTest.AppendLine($"{pr.Name}\n {string.Join("\n  ",
                pr.PackageReferences.Select(a => a.Name))}");
        }


        //static List<SolutionProperties> GetNodeSolutions(string rootPath)
        //{
        //    var solutions = new List<SolutionProperties>();
        //    var nodeFiles = Directory.GetFiles(rootPath, "package.json", SearchOption.AllDirectories);
        //    nodeFiles = nodeFiles
        //        .Where(a => !a.Contains(@"\node_modules\")
        //                    && !a.Contains(@"\bin\")
        //                    && !a.Contains(@"\obj\")
        //                    && !a.Contains(@"\dist\")
        //                    && !a.Contains(@"\projects")
        //              )
        //        .ToArray();
        //    foreach (var file in nodeFiles)
        //    {
        //        solutions.Add(_solutionService.Parse(file));
        //    }
        //    return solutions;
        //}

    }


}
