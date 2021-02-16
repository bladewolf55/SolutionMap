using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace SolutionReferences
{
    class Program
    {
        static SolutionService solutionService = new SolutionService();
        static void Main(string[] args)
        {
#if DEBUG
            string arg1 = @"C:\Development\biBERK\";
            args = new string[] { arg1 };
#endif
            string rootPath = args[0];
            var solutions = new List<Solution>();

            solutions = solutions.Concat(GetVisualStudioSolutions(rootPath)).ToList();
            //solutions = solutions.Concat(GetNodeSolutions(rootPath)).ToList();


            PrintSolutions(solutions);
            ReadLine();
        }

        static List<Solution> GetVisualStudioSolutions(string rootPath)
        {
            var solutions = new List<Solution>();
            var slnFiles = Directory.GetFiles(rootPath, "*.sln", SearchOption.AllDirectories);
            foreach (var solutionFile in slnFiles)
            {
                solutions.Add(solutionService.Parse(solutionFile));
            }
            return solutions;
        }

        static List<Solution> GetNodeSolutions(string rootPath)
        {
            var solutions = new List<Solution>();
            var nodeFiles = Directory.GetFiles(rootPath, "package.json", SearchOption.AllDirectories);
            nodeFiles = nodeFiles
                .Where(a => !a.Contains(@"\node_modules\")
                            && !a.Contains(@"\bin\")
                            && !a.Contains(@"\obj\")
                            && !a.Contains(@"\dist\")
                            && !a.Contains(@"\projects")
                      )
                .ToArray();
            foreach (var file in nodeFiles)
            {
                solutions.Add(solutionService.Parse(file));
            }
            return solutions;
        }


        static void PrintSolutions(List<Solution> solutions)
        {
            foreach (var solution in solutions)
            {
                PrintProperties(solution);
                foreach (var project in solution.Projects)
                {
                    PrintProperties(project, 2);
                    PrintReferences(project, 4);
                    WriteIndent("---------------------------------",2);
                }
                WriteIndent("=================================");
            }
        }

        static void PrintReferences(Project project, int indent, bool projectReferencesOnly = false)
        {
            var references = project.References;
            if (projectReferencesOnly)
            {
                references = references.Where(a => a.ReferenceType == "Project").ToList();
            }
            foreach (var reference in project.References)
            {
                PrintProperties(reference, indent);
                if (reference.ReferenceType == "Project")
                {
                    PrintReferences(reference.ProjectReference, indent + 2, true);
                }
            }
        }

        
        static void PrintProperties<T>(T obj, int indent = 0) where T: class 
        {
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(obj) ?? "<null>";
                WriteLine($"{" ".Repeat(indent)}  {prop.Name.PadRight(25)}{value}");
            }
        }




        static void WriteIndent(string value, int indent = 0)
        {
            string indentSpaces = indent == 0 ? "" : " ".Repeat(indent);
            WriteLine($"{indentSpaces}{value}");
        }

    }
}
