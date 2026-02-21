if (test-path package) {remove-item package -recurse}
dotnet publish SolutionMapCli --output package