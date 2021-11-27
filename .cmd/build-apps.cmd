@echo off
call %~dp0config.cmd
dotnet build %ZSln% /p:Configuration=%BuildKind% -fl -flp:logfile=%AppsBuildLog%;verbosity=%BuildVerbosity% -graph:true