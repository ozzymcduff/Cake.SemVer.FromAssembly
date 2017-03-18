using System;
using Cake.Core.IO;

namespace Cake.SemVer.FromBinary.Tests
{
    internal class SemVerMagnitudeRunnerFixture : SemVerFixture<SemVerMagnitudeSettings>
    {
        public FilePath Original;

        public FilePath New;

        public SemVerMagnitudeRunnerFixture()
        {
            Original = "c:/temp/original.dll";
            New = "c:/temp/new.dll";
        }
        protected override void RunTool()
        {
            var tool = new SemVerMagnitudeRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.SemVerMagnitude(Original, New, Settings);
        }
    }
}