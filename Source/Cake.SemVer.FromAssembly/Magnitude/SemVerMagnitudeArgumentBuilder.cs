using System;
using Cake.Core;
using Cake.Core.IO;

namespace  Cake.SemVer.FromBinary
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
            if (original == null) throw new ArgumentNullException(nameof(original)); 
            _original = original;
            if (@new == null) throw new ArgumentNullException(nameof(@new));
            _new = @new;
        }
        protected override void AddArguments(ProcessArgumentBuilder builder, SemVerMagnitudeSettings settings)
        {
            builder.Append("--magnitude");

            builder.AppendQuoted( _original.MakeAbsolute(_environment).Normalize());

            builder.AppendQuoted(_new.MakeAbsolute(_environment).Normalize());
        }
    }
}
