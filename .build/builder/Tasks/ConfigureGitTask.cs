using Build.Extensions;
using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;

namespace Build.Tasks;

[TaskName("configure:git")]
public sealed class ConfigureGitTask : FrostingTask
{
    public override void Run(ICakeContext context)
    {
        var gitFile = new FilePath("git.exe");

        // Line ending and symlinks
        context.RunUtil(gitFile, CreateSettings("config core.autocrlf true"));
        context.RunUtil(gitFile, CreateSettings("config core.safecrlf true"));
        context.RunUtil(gitFile, CreateSettings("config core.symlinks true"));
        context.RunUtil(gitFile, CreateSettings("config core.longpaths true"));

        // Fetch settings
        context.RunUtil(gitFile, CreateSettings("config remote.origin.tagOpt --tags"));
        context.RunUtil(gitFile, CreateSettings("config fetch.prune true"));
    }

    private static ProcessSettings CreateSettings(string arguments)
    {
        return new ProcessSettings
        {
            Arguments = arguments
        };
    }
}