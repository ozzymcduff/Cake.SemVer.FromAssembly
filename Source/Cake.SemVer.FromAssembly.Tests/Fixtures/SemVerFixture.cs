using System;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace  Cake.SemVer.FromBinary.Tests
{
    internal abstract class SemVerFixture<TSettings>:ToolFixture<TSettings>
                      where TSettings : ToolSettings, new()
    {
        protected SemVerFixture():base("SynVer.exe")
        {
        }
    }
}
