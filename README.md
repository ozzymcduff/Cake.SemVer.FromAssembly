# Cake.SemVer.FromAssembly [![Build status](https://ci.appveyor.com/api/projects/status/7bge00kxk3m4x807/branch/master?svg=true)](https://ci.appveyor.com/project/wallymathieu/cake-semver-fromassembly/branch/master)

Cake Addin that exends Cake with ability to execute the SemVer.FromAssembly tool

## Obsolete

Consider using [Cake.SynVer](https://github.com/fsprojects/Cake.SynVer) instead.

## Usage 

```
#addin Cake.SemVer.FromBinary
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
