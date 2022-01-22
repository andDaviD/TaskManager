using Cake.Common;
using Cake.Common.Diagnostics;
using Cake.Core;
using Cake.Core.IO;

namespace Build.Extensions;

internal static class RunExtensions
{
    public static void RunUtil(this ICakeContext context, FilePath filePath, ProcessSettings processSettings)
    {
        var command = $"{filePath.GetFilename()} {processSettings.Arguments.Render()}";

        context.Information(command);

        using var process = context.StartAndReturnProcess(filePath, processSettings);

        process.WaitForExit();

        var exitCode = process.GetExitCode();

        if (exitCode != 0)
        {
            throw new CakeException($"Run '{command}': Process returned an error (exit code {exitCode}).");
        }
    }
}
