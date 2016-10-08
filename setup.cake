var rootDirectoryPath         = MakeAbsolute(Context.Environment.WorkingDirectory);
var solutionFilePath          = "./Source/Cake.SemVer.FromAssembly.sln";

#tool nuget:?package=xunit.runner.console

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("NuGet-Package-Restore")
    .Does(() =>
{
    NuGetRestore(solutionFilePath);
});

Task("Build")
    .IsDependentOn("NuGet-Package-Restore")
    .Does(() =>
{
    MSBuild(solutionFilePath, new MSBuildSettings()
        .SetConfiguration(configuration)
        .WithProperty("Windows", "True")
        .WithProperty("TreatWarningsAsErrors", "False")
        .UseToolVersion(MSBuildToolVersion.VS2015)
        .SetVerbosity(Verbosity.Minimal)
        .SetNodeReuse(false));
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories(new[] { "./BuildArtifacts/TestResults" });
});

Task("Run-xUnit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    XUnit2("./Source/**/bin/" + configuration + "/*Tests.dll", new XUnit2Settings {
        OutputDirectory = "./BuildArtifacts/TestResults",
        XmlReportV1 = true,
        NoAppDomain = true
    });
});

Task("Default")
  .IsDependentOn("Run-xUnit-Tests");

RunTarget(target);
