using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SemVer.FromAssembly
{
    public class SemVerSettings : ToolSettings
    {
        public FilePath Output { get; set; }
    }
}
