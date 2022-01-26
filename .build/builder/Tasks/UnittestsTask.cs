using System.Linq;
using Cake.Common.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNetCore.Test;
using Cake.Frosting;

namespace Build.Tasks;

[TaskName("unittests")]
public sealed class UnittestsTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var testDirectory = context.RootDirectory.CombineWithFilePath("./**/*Tests.csproj").FullPath;
        var testAssemblies = context.GetFiles(testDirectory).ToList();

        foreach (var project in testAssemblies)
        {
            context.DotNetTest(project.FullPath, new DotNetCoreTestSettings
            {
                NoBuild = true,
                Configuration = context.Configuration
            });
        }
    }
}