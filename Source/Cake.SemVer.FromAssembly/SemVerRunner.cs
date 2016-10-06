using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SemVer.FromAssembly
{
	class SemVerRunner
	{
		ICakeEnvironment environment;
		IFileSystem fileSystem;
		IProcessRunner processRunner;
		IToolLocator tools;

		public SemVerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
		{
			this.fileSystem = fileSystem;
			this.environment = environment;
			this.processRunner = processRunner;
			this.tools = tools;
		}

        public string Magnitude(FilePath original, FilePath @new)
        {
            throw new NotImplementedException();
        }
   }
}