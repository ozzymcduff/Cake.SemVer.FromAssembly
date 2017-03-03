using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using System.Runtime.InteropServices;
namespace Cake.SemVer.FromBinary
{
    /// <summary>
    /// <para>Contains functionality related to the <see href="https://github.com/wallymathieu/SemVer.FromAssembly">SemVer.FromAssembly</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, the SemVer.FromAssembly utility will need to be installed and available, or you will need to provide a ToolPath to where it can be located, and also you will need to include the following in your build.cake file to download and
    /// reference the addin from NuGet.org:
    /// <code>
    /// #addin Cake.SemVer.FromAssembly
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("SemVer")]
    [ComVisible(true)]
    public static class SemVerAliases
    {
        /// <summary>
        /// Get the magnitude by running SemVer.FromAssembly.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="original">the previously published dll</param>
        /// <param name="next">the dll to be published</param>
        /// <example>
        /// <code>
        /// SemVerMagnitude("./packages/NAME/45/NAME.dll", "NAME/bin/Debug/NAME.dll");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static Magnitude SemVerMagnitude(this ICakeContext context, FilePath original, FilePath next)
        {
            return SemVerMagnitude(context, original, next, null);
        }
        /// <summary>
        /// Get the magnitude by running SemVer.FromAssembly.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="original">the previously published dll</param>
        /// <param name="next">the dll to be published</param>
        /// <param name="output">send output to a file</param>
        /// <example>
        /// <code>
        /// SemVerMagnitude("./packages/NAME/45/NAME.dll", "NAME/bin/Debug/NAME.dll", "output.txt");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static Magnitude SemVerMagnitude(this ICakeContext context, FilePath original, FilePath next, FilePath output)
        {
            var runner = new SemVerMagnitudeRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.SemVerMagnitude(original, next, new SemVerMagnitudeSettings { Output = output });
        }
    }
}
