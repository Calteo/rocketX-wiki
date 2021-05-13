using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Docfx.Create.Toc
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
