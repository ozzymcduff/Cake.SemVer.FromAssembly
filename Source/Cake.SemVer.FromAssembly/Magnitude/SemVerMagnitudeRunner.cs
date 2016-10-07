using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SemVer.FromAssembly
{
	internal class SemVerMagnitudeRunner: SemVerTool<SemVerMagnitudeSettings>
	{
        private readonly ICakeEnvironment _environment;

		public SemVerMagnitudeRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            :base(fileSystem,environment,processRunner,tools)
		{
            _environment = environment;
		}

        public string Magnitude(FilePath original, FilePath @new, SemVerMagnitudeSettings settings)
        {
            return RunTool(settings, new SemVerMagnitudeArgumentBuilder(_environment, original, @new, settings));
        }
   }
}