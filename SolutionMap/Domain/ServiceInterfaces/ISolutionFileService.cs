using SolutionMap.Domain.Models;

namespace SolutionMap.Domain.ServiceInterfaces;

public interface ISolutionFileService
{
    SolutionFile ParseVisualStudioSolution(string filePath);
}
