namespace SolutionMapWinform;

public class AppSettings
{
    public const string SqliteDatabaseFileName = "solutionmap.db";
    public static string GetSqliteDatabaseFilePath() => Path.Combine(Properties.Settings.Default.SqliteDatabaseFolder, AppSettings.SqliteDatabaseFileName);

}
