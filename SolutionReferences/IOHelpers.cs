using System.IO;

namespace SolutionReferences
{
    public static class IOHelpers
    {
        public static string CombineToNormalizedPath(params string[] paths)
        {
            var newPath = Path.Combine(paths);
            return Path.GetFullPath(newPath);
        }
    }
}
