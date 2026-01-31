using System;
using System.IO;
using CommandLineParser.Arguments;
using SolutionMap.DataImport;

namespace SolutionMap;

class Program
{

    static void Main(string[] args)
    {
#if DEBUG
        var argS = Environment.ExpandEnvironmentVariables(@"%UserProfile%\source\repos\");
        var argD = Path.Join(argS, "SolutionMapDb", "solutionMap.db");

        args = new string[]
        {
            "-s", argS, // Update this path to your local solutions directory
            "-d", argD  // Update this path to your desired SQLite database file location
        };
#endif

        CommandLineParser.CommandLineParser parser = new();
        parser.ShowUsageHeader = "SolutionMap CLI - A tool to import Visual Basic solutions into a SQLite database.";

        SwitchArgument showHelp = new('h', "help", "Show help info", false);

        DirectoryArgument solutionsPath = new('s', "solutions-path", "Path to the directory containing Visual Basic solutions. Directory must exist.");
        solutionsPath.Optional = false;
        solutionsPath.DirectoryMustExist = true;

        FileArgument sqlitePath = new('d', "sqlitedb-path", "Path to the SQLite database file. File will be (re)created.");
        sqlitePath.Optional = false;
        sqlitePath.FileMustExist = false;

        parser.Arguments.Add(showHelp);
        parser.Arguments.Add(solutionsPath);
        parser.Arguments.Add(sqlitePath);

        try
        {
            parser.ParseCommandLine(args);
            if (showHelp.Parsed)
            {
                parser.ShowUsage();
                return;
            }
            if (!solutionsPath.Parsed)
            {
                Console.WriteLine("Error: Existing solution path is required.");
                parser.ShowUsage();
                return;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}\n");
            parser.ShowUsage();
            return;
        }

        try
        {
            var solutionFilesPath = solutionsPath.Value.ToString();
            var sqliteFilePath = sqlitePath.Value.ToString();

            Console.WriteLine($"Solution Files Path         {solutionFilesPath}");
            Console.WriteLine($"SQLite Database File Path   {sqliteFilePath}");
            Console.WriteLine();

            var dataImportService = new DataImportService();
            dataImportService.ImportStatus += (sender, e) =>
            {
                Console.WriteLine(e.Message);
            };

            dataImportService.ImportVisualBasicSolutions(sqliteFilePath, solutionFilesPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
