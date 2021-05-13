using System.ComponentModel;
using Toolbox.CommandLine;

namespace Docfx.Create.Toc
{
    class TocOptions
    {
        [Option("folder"), Position(0), Description("folder containing the docfx project")]
        public string Folder { get; set; }
    }
}
