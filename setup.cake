///////////////////////////////////////////////////////////////////////////////
// ENVIRONMENT VARIABLE NAMES
///////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////
// BUILD ACTIONS
///////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////
// PROJECT SPECIFIC VARIABLES
///////////////////////////////////////////////////////////////////////////////

var rootDirectoryPath         = MakeAbsolute(Context.Environment.WorkingDirectory);
var solutionFilePath          = "./Source/Cake.SemVer.FromAssembly.sln";
var solutionDirectoryPath     = "./Source/Cake.SemVer.FromAssembly";
var title                     = "Cake.SemVer.FromAssembly";
var repositoryOwner           = "wallymathieu";
var repositoryName            = "Cake.SemVer.FromAssembly";
var appVeyorAccountName       = "wallymathieu";
var appVeyorProjectSlug       = "cake-semver-from-assembly";


///////////////////////////////////////////////////////////////////////////////
// CAKE FILES TO LOAD IN
///////////////////////////////////////////////////////////////////////////////

#l .\Tools\gep13.DefaultBuild\Content\appveyor.cake
#l .\Tools\gep13.DefaultBuild\Content\chocolatey.cake
#l .\Tools\gep13.DefaultBuild\Content\nuget.cake
#l .\Tools\gep13.DefaultBuild\Content\packages.cake
#l .\Tools\gep13.DefaultBuild\Content\paths.cake
#l .\Tools\gep13.DefaultBuild\Content\testing.cake
#l .\Tools\gep13.DefaultBuild\Content\build.cake
