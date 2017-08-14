cd .\Internals
call .\Build_Release.bat
Powershell.exe -executionpolicy remotesigned -File .\CommitAndPush_Git.ps1

exit