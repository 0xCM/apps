@echo off
set SlnRoot=%ZDev%
set FrameworkMoniker=netcoreapp3.1
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildRoot=%SlnRoot%\.build
set BuildLogs=%BuildRoot%\logs
set ZLibProj=%SlnRoot%\lib\z0.lib.csproj
set ZSln=%SlnRoot%\z0.sln
set BuildPlatform="Any CPU"
set ZLibBuildLog=%BuildLogs%\z0.lib.log
set AppsBuildLog=%BuildLogs%\z0.apps.log
set BuildLibsCmd=dotnet build %ZLibProj% /p:Configuration=%BuildKind% /p:Platform=%BuildPlatform% -fl -flp:logfile=%ZLibBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
