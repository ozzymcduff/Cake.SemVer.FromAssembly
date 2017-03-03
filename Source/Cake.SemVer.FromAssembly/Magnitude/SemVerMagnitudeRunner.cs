using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace  Cake.SemVer.FromBinary
{
    internal class SemVerMagnitudeRunner : SemVerTool<SemVerMagnitudeSettings>
    {
        private readonly ICakeEnvironment _environment;

        public SemVerMagnitudeRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        public Magnitude SemVerMagnitude(FilePath original, FilePath @new, SemVerMagnitudeSettings settings)
        {
            var res = RunTool(settings, new SemVerMagnitudeArgumentBuilder(_environment, original, @new, settings));
            Magnitude magnitude;
            if (Enum.TryParse(res, out magnitude))
            {
                return magnitude;
            }
            return Magnitude.None;
        }
    }
}