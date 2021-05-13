using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docfx.Common
{
    [DebuggerDisplay("{Name,nq} - {Title}")]
    public class TocItem
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public List<TocItem> Items { get; set; } = new List<TocItem>();

        public virtual void WriteYaml(StreamWriter writer, int indent)
        {
            writer.Write(new string(' ', indent));
            writer.WriteLine($"- name: {Title}");
        }
    }
}
