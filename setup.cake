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
    CleanDirectories(new[] { "./BuildArtifacts/TestResults", "./BuildArtifacts/nuget" });
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


Task("Package")
    .IsDependentOn("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var nuGetPackSettings   = new NuGetPackSettings {
        Id                      = "Cake.SemVer.FromBinary",
        Version                 = "0.0.3",
        Title                   = "Cake addin to use SemVer.FromAssembly",
        Authors                 = new[] {"Oskar Gewalli"},
        Owners                  = new[] {"Oskar Gewalli"},
        Description             = "Cake addin in order to be able to get next semver version of nuget package based on changes to the public API",
        ProjectUrl              = new Uri("https://github.com/wallymathieu/Cake.SemVer.FromAssembly"),
        LicenseUrl              = new Uri("https://raw.githubusercontent.com/wallymathieu/Cake.SemVer.FromAssembly/master/LICENSE"),
        Copyright               = "wallymathieu 2016",
        ReleaseNotes            = new string[]{"Renamed parameter new to next"},
        Tags                    = new [] {"semver", "Cake"},
        RequireLicenseAcceptance= false,
        Symbols                 = true,
        NoPackageAnalysis       = true,
        Files                   = new [] {
            new NuSpecContent {Source = "Cake.SemVer.FromBinary.dll", Target = "/"},
            new NuSpecContent {Source = "Cake.SemVer.FromBinary.XML", Target = "/"},
        },
        BasePath                = "./Source/Cake.SemVer.FromAssembly/bin/" + configuration,
        OutputDirectory         = "./BuildArtifacts/nuget"
    };

    NuGetPack(nuGetPackSettings);
});

Task("Default")
  .IsDependentOn("Run-xUnit-Tests");

RunTarget(target);
