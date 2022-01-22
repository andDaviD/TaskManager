using System.Collections.Generic;
using System.Linq;
using Cake.Common.Diagnostics;
using Cake.Common.IO;
using Cake.Core.IO;
using Cake.Frosting;

namespace Build.Tasks;

[TaskName("clean")]
public sealed class CleanTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var settings = new DeleteDirectorySettings { Recursive = true, Force = true };

        var paths = new List<DirectoryPath> { new($"{context.RootDirectory}/build") };
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/node_modules"));
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/packages"));
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/bin"));
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/obj"));
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/dist"));
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/logs"));
        paths.AddRange(context.GetDirectories($"{context.RootDirectory}/**/artifacts"));

        foreach (var path in paths.Where(p => !p.FullPath.Contains("/.")).Where(context.DirectoryExists))
        {
            context.Information(context.MakeAbsolute(path));
            context.DeleteDirectory(path, settings);
        }
    }
}