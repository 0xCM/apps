@echo off
set SlnRoot=%ZDev%
set FrameworkMoniker=netcoreapp3.1
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildRoot=%SlnRoot%\.build
set BuildLogs=%BuildRoot%\logs
set ZLibProj=%SlnRoot%\lib\z0.lib.csproj
set TestSln=%SlnRoot%\test\z0.test.sln
set CgSln=%SlnRoot%\codegen\z0.codegen.sln
set ZSln=%SlnRoot%\z0.sln
set BuildPlatform="Any CPU"
set ZLibBuildLog=%BuildLogs%\z0.lib.log
set TestBuildLog=%BuildLogs%\z0.test.log
set AppsBuildLog=%BuildLogs%\z0.apps.log
set CgBuildLog=%BuildLogs%\z0.codegen.log
set BuildLibsCmd=dotnet build %ZLibProj% /p:Configuration=%BuildKind% /p:Platform=%BuildPlatform% -fl -flp:logfile=%ZLibBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildTestCmd=dotnet build %TestSln% /p:Configuration=%BuildKind% /p:Platform=%BuildPlatform% -fl -flp:logfile=%TestBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgCmd=dotnet build %CgSln% /p:Configuration=%BuildKind% /p:Platform=%BuildPlatform% -fl -flp:logfile=%CgBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildAppsCmd=dotnet build %ZSln% /p:Configuration=%BuildKind% /p:Platform=%BuildPlatform% -fl -flp:logfile=%AppsBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24