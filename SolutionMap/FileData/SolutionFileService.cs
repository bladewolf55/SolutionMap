using SolutionMap.Domain.Models;
using SolutionMap.Domain.ServiceInterfaces;

namespace SolutionMap.FileData;

public class SolutionFileService : ISolutionFileService
{
    public SolutionFile ParseVisualStudioSolution(string filePath)
    {
        var helper = new VisualStudioSolutionHelpers();
        var solutionFile = helper.Parse(filePath);
        return solutionFile;
    }
}
