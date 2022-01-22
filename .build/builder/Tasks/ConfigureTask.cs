using Cake.Frosting;

namespace Build.Tasks;

[TaskName("configure")]
[IsDependentOn(typeof(ConfigureGitTask))]
public sealed class ConfigureTask : FrostingTask
{
}
