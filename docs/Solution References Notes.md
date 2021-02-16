Initial Project Types to Parse

*   ASP.NET Core
*   ASP.NET Framework
*   Class Library Core
*   Class Library Framework
*   Class Library Standard
*   Angular on Node
*   Aurelia on .NET



## Framework

### Solution File
```

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.31005.135
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ClassLibraryFramework", "ClassLibraryFramework\ClassLibraryFramework.csproj", "{D55FCA20-C8A1-41F2-9440-0C2D912AD6B1}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{D55FCA20-C8A1-41F2-9440-0C2D912AD6B1}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D55FCA20-C8A1-41F2-9440-0C2D912AD6B1}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D55FCA20-C8A1-41F2-9440-0C2D912AD6B1}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D55FCA20-C8A1-41F2-9440-0C2D912AD6B1}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {E7DA37FE-4F15-46BA-B0CC-BFFDA325A41D}
	EndGlobalSection
EndGlobal
```

```csharp

public class Solution 
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public List<Project> Projects { get; set; } = new List<Project>();
}

public class VisualStudioSolution: Solution
{
    public string FormatVersion { get; set; }
    public string VisualStudioVersion { get; set; }
    public string MinimumVisualStudioVersion { get; set; }
}

public class Project 
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string FilePath { get; set; }
    
    public Solution Solution { get; set; }
}

public class VisualStudioFrameworkProject: Project
{
    public string ProjectTypeGuids { get; set; }
    public string OutputType { get; set; }
    public string AssemblyName { get; set; }
    public string RootNamespace { get; set; }
    public string TargetFramework { get; set; }
    public List<Reference> References { get; set; } = new List<Reference>();
}

public class VisualStudioCoreProject: Project
{
    public string Sdk { get; set; }
    public string TargetFramework { get; set; }
    public string PackageId { get; set; } // default: Project Name
    public string PackageVersion { get; set; } // default: 1.0.0
    public string AssemblyVersion { get; set; } // default: 1.0.0.0
    public string AssemblyFileVersion { get; set; } // default: 1.0.0.0
    public string InformationalVersion => PackageVersion
    public string AssemblyName { get; set; } // default Project Name
    public string RootNamespace { get; set; } // default Project Name
    public List<Reference> References { get; set; } = new List<Reference>();
}

public class Reference
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string Version { get; set; }
    public string ReferenceType { get; set; }
    public Project Project { get; set; }
}



```