using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.SemVer.FromAssembly
{
    internal class SemVerMagnitudeArgumentBuilder: SemVerArgumentBuilder<SemVerMagnitudeSettings>
    {
        FilePath _new;
        FilePath _original;
        ICakeEnvironment _environment;


        public SemVerMagnitudeArgumentBuilder(ICakeEnvironment environment, FilePath original, FilePath @new, SemVerMagnitudeSettings settings)
            :base(environment,settings)
        {
            _environment = environment;
            _original = original;
            _new = @new;
        }
        protected override void AddArguments(ProcessArgumentBuilder builder, SemVerMagnitudeSettings settings)
        {
            builder.Append("--magnitude");

            builder.AppendQuoted(_original.MakeAbsolute(_environment).FullPath);

            builder.AppendQuoted(_new.MakeAbsolute(_environment).FullPath);
        }
    }
}
