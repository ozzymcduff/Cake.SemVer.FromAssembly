using System;
namespace Cake.SemVer.FromAssembly
{
    public enum Magnitude
    {
        /// <summary>
        /// Could be due to an error.
        /// </summary>
        None=0,
        Patch = 1,
        Minor = 2,
        Major = 3
    }
}
