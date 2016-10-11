# Cake.SemVer.FromAssembly [![Build status](https://ci.appveyor.com/api/projects/status/8de3t84iae9utkcd/branch/master?svg=true)](https://ci.appveyor.com/project/wallymathieu/semver-fromassembly/branch/master)

Cake Addin that exends Cake with ability to execute the SemVer.FromAssembly tool

## Usage 

```
#addin Cake.SemVer.FromAssembly
```

```
Task("Build-Next")
    .Does(() =>
{
    var magnitude=SemVerMagnitude("./packages/NAME/45/NAME.dll", "NAME/bin/Debug/NAME.dll");
    switch(magnitude){
    case Magnitude.Major:
     // update major version
    case Magnitude.Minor:
     // update minor version
    case Magnitude.Patch:
     // update patch version
    }
});
```
