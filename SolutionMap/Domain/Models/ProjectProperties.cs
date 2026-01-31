namespace SolutionMap.Domain.Models;

public record ProjectProperties
{
	public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
	public string AssemblyVersion { get; set; } = string.Empty;
	public string FilePath { get; set; } = string.Empty;
    public string ProjectType { get; set; } = string.Empty;
    public string AssemblyName { get; set; } = string.Empty;
    public string RootNamespace { get; set; } = string.Empty;
    public string TargetFramework { get; set; } = string.Empty;
    public string PackageId { get; set; } = string.Empty;
    public string PackageVersion { get; set; } = string.Empty;
    public string AssemblyFileVersion { get; set; } = null!;
    public string InformationalVersion => PackageVersion;
}

