namespace Tools.ProjectStats.Commands
{
    using System.IO;
    using System.Linq;
    using System;
    using Tools.ProjectStats.Utils;

    public class FilesCommand
    {
        public int Execute(string path)
        {
            Preconditions.CheckNotNull(path, nameof(path));

            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            var extensionsCount = files
                .GroupBy(Path.GetExtension)
                .Select(g => new
                {
                    Extension = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(f => f.Count);


            Console.WriteLine($"Total number of files {files.Length}");
            Console.WriteLine();

            Console.WriteLine($"Extension\t\tCount");
            Console.WriteLine();

            foreach (var extensionStats in extensionsCount)
            {
                Console.WriteLine($"{extensionStats.Extension}\t\t\t{extensionStats.Count}");
            }


            return 0;
        }
    }
}
