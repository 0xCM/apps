@echo off
call %~dp0config.cmd
set ProjName=z0.%ProjId%
set ProjRoot=%DevRoot%\%ProjId%
set ProjPath=%ProjRoot%\%ProjName%.csproj
set BuildLogPath=%BuildLogs%\%ProjName%.log
set ProjBuildRoot=%BuildRoot%\bin\%ProjName%
set ProjBinRoot=%ProjBuildRoot%\%Configuration%
set ExeTargetRoot=%ProjBinRoot%\%FrameworkMoniker%\%RtId%
set ExeTargetPath=%ExeTargetRoot%\%AppName%.exe
set BuildProjCmd=dotnet build %ProjectPath% -c %Configuration% -fl -flp:logfile=%BuildLogPath%;verbosity=%BuildVerbosity% -graph:true
