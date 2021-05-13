using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Docfx.Create.Toc
{
    public class TocEntry : TocItem
    {
        public bool IsIndex => Name == "index.md";        
        public string Uid { get; private set; }
        public string Parent { get; private set; }
        public TocFolder Linked { get; set; }

        private static Regex KeyValuePattern { get; } = new Regex(@"^\s*(?<key>[^:]+)\s*:\s*(?<value>.+?)\s*$", RegexOptions.Compiled);

        static public TocEntry Scan(FileInfo file)
        {
            var toc = new TocEntry { Name = file.Name };
            
            using (var stream = file.OpenText())
            {
                var line = stream.ReadLine();
                if (line == "---")
                {
                    do
                    {
                        line = stream.ReadLine();
                        var match = KeyValuePattern.Match(line);
                        if (match.Success)
                        {
                            var key = match.Groups["key"].Value;
                            var value = match.Groups["value"].Value;
                            switch (key)
                            {
                                case "title":
                                    toc.Title = value;
                                    break;
                                case "uid":
                                    toc.Uid = value;
                                    break;
                                case "toc.parent":
                                    toc.Parent = value;
                                    break;
                                case "toc.order":
                                    if (int.TryParse(value, out var index))
                                        toc.Order = index;
                                    break;
                            }
                        }
                    }
                    while (line != "---" && line != "");
                }
            }

            if (toc.Title == null)
            {
                toc.Title = Path.GetFileNameWithoutExtension(file.Name);
                toc.Title = toc.Title.Substring(0, 1).ToUpper() + toc.Title[1..];
            }
            if (toc.Uid == null)
                toc.Uid = Guid.NewGuid().ToString();

            return toc;
        }

        public override void WriteYaml(StreamWriter writer, int indent)
        {
            base.WriteYaml(writer, indent);

            if (Linked == null)
            {
                writer.Write(new string(' ', indent));
                writer.WriteLine($"  href: {Name}");

                if (Items.Count > 0)
                    writer.WriteLine($"  items:");

                foreach (var item in Items)
                {
                    item.WriteYaml(writer, indent + 2);
                }
            }
            else
            {
                writer.Write(new string(' ', indent));
                writer.WriteLine($"  href: {Linked.Name}/toc.yml");
                writer.Write(new string(' ', indent));
                writer.WriteLine($"  topicHref: {Name}");
                Linked.WriteToc();
            }
        }
    }
}
