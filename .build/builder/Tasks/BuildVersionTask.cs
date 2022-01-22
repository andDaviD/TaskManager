using System;
using System.Text;
using Build.Extensions;
using Cake.Common.Diagnostics;
using Cake.Common.IO;
using Cake.Common.Tools.GitVersion;
using Cake.Core;
using Cake.Core.IO;
using Cake.FileHelpers;
using Cake.Frosting;

namespace Build.Tasks;

[TaskName("build:version")]
public sealed class BuildVersionTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.EnsureDirectoryExists(context.RootDirectory.Combine("build"));

        GitVersion gitVersion = context.GitVersion(
            new GitVersionSettings
            {
                NoFetch = true
            });

        string branchName = gitVersion.BranchName;
        string shortSha = gitVersion.Sha.Substring(0, 8);
        string versionPrefix = gitVersion.MajorMinorPatch;
        string versionSuffix = $"sha{shortSha}";

        context.Information($"Using version: {versionPrefix}-{versionSuffix}");

        FilePath versionFile = context.BuildDirectory.CombineWithFilePath("Version.props");

        context.Information($"Create file: {versionFile}");

        var builder = new StringBuilder();
        builder.AppendLine("<Project>");
        builder.AppendLine();
        builder.AppendLine("  <PropertyGroup>");
        builder.AppendLine($"    <RepositoryUrl>{GetRepositoryUrl(context)}</RepositoryUrl>");
        builder.AppendLine($"    <RepositoryBranch>{branchName}</RepositoryBranch>");
        builder.AppendLine($"    <RepositoryCommit>{shortSha}</RepositoryCommit>");
        builder.AppendLine();
        builder.AppendLine($"    <Configuration>{context.Configuration}</Configuration>");
        builder.AppendLine($"    <VersionPrefix>{versionPrefix}</VersionPrefix>");
        builder.AppendLine($"    <VersionSuffix>{versionSuffix}</VersionSuffix>");
        builder.AppendLine("  </PropertyGroup>");
        builder.AppendLine();
        builder.AppendLine("</Project>");

        context.FileWriteText(versionFile, builder.ToString());
    }

    private static string GetRepositoryUrl(ICakeContext context)
    {
        string result = null;

        var processSettings = new ProcessSettings
        {
            Arguments = "config --get remote.origin.url",
            RedirectStandardOutput = true,
            RedirectedStandardOutputHandler = text =>
            {
                result = text ?? result;

                return text;
            }
        };

        context.RunUtil(new FilePath("git.exe"), processSettings);

        return new Uri(result).GetComponents(
            UriComponents.Scheme |
            UriComponents.Host |
            UriComponents.PathAndQuery,
            UriFormat.UriEscaped);
    }
}