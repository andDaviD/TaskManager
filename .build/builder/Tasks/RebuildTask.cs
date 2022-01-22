using Cake.Frosting;

namespace Build.Tasks;

[TaskName("rebuild")]
[IsDependentOn(typeof(CleanTask))]
[IsDependentOn(typeof(BuildTask))]
public sealed class RebuildTask : FrostingTask
{
}