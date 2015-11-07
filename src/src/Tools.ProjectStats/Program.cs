namespace Tools.ProjectStats
{
    using Microsoft.Dnx.Runtime.Common.CommandLine;
    using System;
    using System.IO;
    using Tools.ProjectStats.Commands;

    public class Program
    {
        public int Main(string[] args)
        {
            try
            {
                var app = new CommandLineApplication();
                app.Name = "project-stats";
                app.FullName = "Project Stats";
                app.Description = "Shows stats about a project such as number of files and SLOC";
                app.ShortVersionGetter = () => "1.0.0";
                app.HelpOption("-h");

                app.Command("files", c =>
                {
                    c.Description = "Gets stats about filetypes";

                    var optionProject = c.Option("-p|--project <PATH>", "Path to the project, default is current directory", CommandOptionType.SingleValue);

                    c.HelpOption("-h");

                    c.OnExecute(() =>
                    {
                        var projectPath = optionProject.Value() ?? Directory.GetCurrentDirectory();

                        return new FilesCommand().Execute(projectPath);
                    });
                });

                app.Command("sloc", c =>
                {
                    c.Description = "Gets stats about source lines of code";

                    var optionProject = c.Option("-p|--project <PATH>", "Path to the project, default is current directory", CommandOptionType.SingleValue);
                    var fileTypeArgs = c.Argument("[filetypes]", "Filetype(s) to include, e.g. .cs .json", multipleValues: true);

                    c.HelpOption("-h");

                    c.OnExecute(() =>
                    {
                        var projectPath = optionProject.Value() ?? Directory.GetCurrentDirectory();
                        var typesFilters = fileTypeArgs.Values;

                        return new SlocCommand().Execute(projectPath, typesFilters);
                    });
                });

                return app.Execute(args);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
