using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SemVer.FromAssembly
{
    internal class SemVerSettings : ToolSettings
    {
        public FilePath Output { get; set; }
    }
}
