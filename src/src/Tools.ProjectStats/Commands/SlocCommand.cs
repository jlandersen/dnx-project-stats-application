namespace Tools.ProjectStats.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Tools.ProjectStats.Utils;

    public class SlocCommand
    {
        public int Execute(string path, IEnumerable<string> fileExtensions)
        {
            Preconditions.CheckNotNull(path, nameof(path));
            Preconditions.CheckNotNull(fileExtensions, nameof(fileExtensions));

            if (!fileExtensions.Any())
            {
                fileExtensions = new string[] { ".*" };
            }

            var files = fileExtensions.SelectMany(ex =>  Directory.GetFiles(path, $"*{ex}", SearchOption.AllDirectories));
            var totalLinesOfCode = files.Sum(f => File.ReadAllLines(f).Length);

            Console.WriteLine($"Total SLOC: {totalLinesOfCode}");

            return 0;
        }
    }
}
