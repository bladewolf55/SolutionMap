using SolutionReferences.Domain.Models;

namespace SolutionReferences.Domain.ServiceInterfaces;

public interface ISolutionService
{
    Solution Parse(string filePath);
    Solution ParseNodeSolution(string filePath);
    Solution ParseVisualStudioSolution(string filePath);
}