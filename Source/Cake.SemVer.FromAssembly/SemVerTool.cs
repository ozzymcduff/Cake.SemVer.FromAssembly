using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Globalization;

namespace  Cake.SemVer.FromBinary
{
    internal class SemVerTool<TSettings> : Tool<TSettings>
        where TSettings : SemVerSettings
    {
        public SemVerTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)

        {
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName()
        {
            return "SemVer.FromAssembly";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "SemVer.FromAssembly.exe" };
        }

        /// <summary>
        /// Runs the SemVer.FromAssembly tool with the specified settings.
        /// </summary>
        /// <typeparam name="TBuilder">The Gem argument builder.</typeparam>
        /// <param name="settings">The settings.</param>
        /// <param name="builder">The builder.</param>
        protected string RunTool<TBuilder>(TSettings settings, TBuilder builder)
            where TBuilder : SemVerArgumentBuilder<TSettings>
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            using (var process = RunProcess(settings, builder.GetArguments()))
            {
                process.WaitForExit();
                var output = process.GetStandardOutput();
                if (process.GetExitCode() == 0)
                {
                    return string.Join(Environment.NewLine,
                                   output??new string[0]);
                }
                else
                {
                    throw new CakeException(string.Format(CultureInfo.InvariantCulture, 
                        "{0}: Process returned an error (exit code {1}).", GetToolName(), process.GetExitCode()));
                }
            }
        }
    }
}
