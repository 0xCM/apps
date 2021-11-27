@echo off
call %~dp0config.cmd
dotnet build %ZLibProj% /p:Configuration=%BuildKind% /p:Platform=%BuildPlatform% -fl -flp:logfile=%ZLibBuildLog%;verbosity=%BuildVerbosity% -graph:true
