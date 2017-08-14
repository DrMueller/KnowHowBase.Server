cd .\Internals
Powershell.exe -executionpolicy remotesigned -File .\Build_Release.ps1
Powershell.exe -executionpolicy remotesigned -File .\CommitAndPush_Git.ps1

exit