using System;
using System.Runtime.InteropServices;

namespace  Cake.SemVer.FromBinary
{
    [ComVisible(true)]
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
