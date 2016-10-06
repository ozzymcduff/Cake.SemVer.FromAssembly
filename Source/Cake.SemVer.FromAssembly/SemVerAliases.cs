using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
namespace Cake.SemVer.FromAssembly
{
    /// <summary>
    /// <para>Contains functionality related to the <see href="https://rubygems.org/pages/download">RubyGems Package Manager</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, the gem utility will need to be installed and available, or you will need to provide a ToolPath to where it can be located, and also you will need to include the following in your build.cake file to download and
    /// reference the addin from NuGet.org:
    /// <code>
    /// #addin Cake.Gem
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("SemVer")]
    public static class SemVerAliases
    {
        /// <summary>
        /// Builds the gem using the path to the gemspec file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="original"></param>
        /// <param name="new"></param>
        /// <example>
        /// <code>
        /// Magnitude("./packages/NAME/45/NAME.dll", "NAME/bin/Debug/NAME.dll");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static string Magnitude(this ICakeContext context, FilePath original, FilePath @new)
        {
            var runner = new SemVerRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Magnitude(original, @new);
        }
    }
}
