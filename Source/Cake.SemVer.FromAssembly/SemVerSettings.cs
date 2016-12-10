using Cake.Core.IO;
using Cake.Core.Tooling;

namespace  Cake.SemVer.FromBinary
{
    internal class SemVerSettings : ToolSettings
    {
        public FilePath Output { get; set; }
    }
}
