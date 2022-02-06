using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Build;
using Cake.Frosting;

namespace Build.Tasks;

[TaskName("build:backend")]
public sealed class BuildBackendTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var settings = new DotNetBuildSettings
        {
            Configuration = context.Configuration
        };
        
        context.DotNetBuild(context.SolutionFile.FullPath, settings);
    }
}