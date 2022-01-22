using Cake.Common;
using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;

namespace Build;

public class BuildContext : FrostingContext
{
    public BuildContext(ICakeContext context)
        : base(context)
    {
        Configuration = context.Argument("configuration", "Debug");
    }
        
    public DirectoryPath ArtifactsDirectory => BuildDirectory.Combine("artifacts");

    public DirectoryPath BuildDirectory => RootDirectory.Combine("build");
    
    public DirectoryPath PublishDirectory => BuildDirectory.Combine("publish");

    public new string Configuration { get; }
    
    public DirectoryPath RootDirectory => Environment.WorkingDirectory.Combine("..").Collapse();

    public FilePath SolutionFile => RootDirectory.CombineWithFilePath("TaskManager.sln");
}