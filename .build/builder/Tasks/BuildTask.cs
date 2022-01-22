using Cake.Frosting;

namespace Build.Tasks;

[TaskName("build")]
//[IsDependentOn(typeof(BuildVersionTask))]
[IsDependentOn(typeof(BuildBackendTask))]
public sealed class BuildTask : FrostingTask
{
}