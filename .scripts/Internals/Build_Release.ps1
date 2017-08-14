$path = $PSScriptRoot

$internalPath  = [IO.Path]::GetDirectoryName($path) -replace '\\+$'
$solutionPath  = [IO.Path]::GetDirectoryName($internalPath) -replace '\\+$'

$solutionPathItems = get-childitem $solutionPath
$solutionItems = $solutionPathItems | where {$_.extension -eq ".sln"}
$sln = $solutionItems[0];

[string]$solutionPath = $sln.FullName;
cd "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\";
./MsBuild.exe  $solutionPath /t:Build /p:Configuration=Release /p:TargetFramework=netcoreapp1.1 /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

exit