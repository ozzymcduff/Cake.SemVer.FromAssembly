var target = Argument("target", "Default");
#addin nuget:?package=Cake.SemVer.FromBinary

Task("Default")
    .Does(() =>
{
    try
    {
        var file = "../packages/xunit.abstractions.2.0.0/lib/net35/xunit.abstractions.dll";
        /*var magnitude=SemVerMagnitude(file, file);
        switch(magnitude){
        case Magnitude.Major:
            Console.WriteLine("Major");
         // update major version
        case Magnitude.Minor:
            Console.WriteLine("Minor");
         // update minor version
        case Magnitude.Patch:
            Console.WriteLine("Patch");
         // update patch version
        }*/

    }
    catch(Exception ex)
    {
       Error("{0}", ex);
    }
});

RunTarget(target);