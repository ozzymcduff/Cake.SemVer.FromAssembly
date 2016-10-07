using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SemVer.FromAssembly
{
    public class SemVerTool<TSettings> : Tool<TSettings>
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
        /// Runs the Gem tool with the specified settings.
        /// </summary>
        /// <typeparam name="TBuilder">The Gem argument builder.</typeparam>
        /// <param name="settings">The settings.</param>
        /// <param name="builder">The builder.</param>
        protected string RunTool<TBuilder>(TSettings settings, TBuilder builder)
            where TBuilder : SemVerArgumentBuilder<TSettings>
        {
            var process= RunProcess(settings, builder.GetArguments());
            process.WaitForExit();
            return string.Join(Environment.NewLine, 
                               process.GetStandardOutput());
        }
    }
}
