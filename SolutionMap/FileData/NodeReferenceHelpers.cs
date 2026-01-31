namespace SolutionMap.FileData;

internal class NodeReferenceHelpers
{
    //    public List<ReferenceProperties> ParseNodeReferences(ProjectProperties project, JsonElement packageJson)
    //    {
    //        var references = new List<ReferenceProperties>();
    //        var dependencies = packageJson.GetProperty("dependencies").EnumerateObject();
    //        foreach (var dependency in dependencies)
    //        {
    //            var reference = new ReferenceProperties();
    //            reference.Name = dependency.Name;
    //            reference.Version = dependency.Value.ToString();
    //            reference.ReferenceType = "Package";
    //            reference.Id = $"{reference.Name}-{reference.Version}";
    //            reference.ParentProject = project;
    //            references.Add(reference);
    //        }

    //        var devDependencies = packageJson.GetProperty("devDependencies").EnumerateObject();
    //        foreach (var dependency in dependencies)
    //        {
    //            var reference = new ReferenceProperties();
    //            reference.Name = dependency.Name;
    //            reference.Version = dependency.Value.ToString();
    //            reference.ReferenceType = "DevPackage";
    //            reference.Id = $"{reference.Name}-{reference.Version}";
    //            reference.ParentProject = project;
    //            references.Add(reference);
    //        }
    //        return references;
    //    }

}
