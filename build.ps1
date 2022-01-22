[CmdletBinding(PositionalBinding = $false)]
param(
    [Parameter(ValueFromRemainingArguments = $true)]
    $Arguments
)

$ErrorActionPreference = 'Stop';

Push-Location;

try
{
    Set-Location (Join-Path $PSScriptRoot ".build");

    &dotnet tool restore;
    &dotnet run --project builder/build.csproj -- $Arguments;

    exit $LASTEXITCODE;
}
finally
{
    Pop-Location;
}