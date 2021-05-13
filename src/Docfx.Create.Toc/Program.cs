using System.Linq;
using System;
using System.IO;
using Toolbox.CommandLine;

namespace Docfx.Create.Toc
{
    class Program
    {
        static int Main(string[] args)
        {
            var parser = Parser.Create<TocOptions>();

            var rc = parser.Parse(args)
                    .OnError(r =>
                    {
                        Console.WriteLine(r.Text);
                        return -1;
                    })
                    .OnHelp(r =>
                    {
                        Console.WriteLine(r.GetHelpText());
                        return 1;
                    })
                    .On<TocOptions>(o => Execute(o)).Return;

            return rc;
        }

        private static int Execute(TocOptions options)
        {
            var folder = Path.GetFullPath(options.Folder ?? Environment.CurrentDirectory);

            Console.WriteLine($"scan folder '{folder}'");

            if (!File.Exists(Path.Combine(folder, "docfx.json")))
            {
                Console.WriteLine($"no docfx project found.");
                return -2;
            }

            var rootToc = TocFolder.Scan(new DirectoryInfo(folder));
            var index = rootToc.Items.OfType<TocEntry>().FirstOrDefault();
            if (index?.IsIndex ?? false)
            {
                rootToc.Items.Remove(index);
            }

            rootToc.WriteToc();

            return 0;
        }
    }
}
