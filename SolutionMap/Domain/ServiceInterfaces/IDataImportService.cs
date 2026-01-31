namespace SolutionMap.Domain.ServiceInterfaces;

public interface IDataImportService
{
    void ImportVisualBasicSolutions(string sqliteFilePath, string solutionsPath);
}
