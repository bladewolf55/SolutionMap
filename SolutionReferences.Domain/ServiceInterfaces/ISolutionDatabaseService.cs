using SolutionReferences.Domain.Models;

namespace SolutionReferences.Domain.ServiceInterfaces;

public interface ISolutionDatabaseService
{
    public void AddSolutionToDatabase(Solution solution);
}
