@echo off
set LogRoot=%DevWs%\projects\db\logs
set EtlLogs=%LogRoot%\etl
mkdir %EtlLogs% 1>nul 2>nul

set BuildLogs=%LogRoot%\build
mkdir %BuildLogs% 1>nul 2>nul

set RepoLogs=%LogRoot%\repos
mkdir %RepoLogs% 1>nul 2>nul

set Archives=%ZArchive%
set RepoArchives=%Archives%\bin\source
set SlnRoot=%ZDev%
set FrameworkMoniker=netcoreapp3.1
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildRoot=%SlnRoot%\.build
set BuildLogs=%BuildRoot%\logs
set ProjectFile=z0.%ProjectId%.csproj
set BinLogPath=%BuildLogs%\z0.%ProjectId%.binlog
set BuildLogPath=%BuildLogs%\z0.%ProjectId%.log
set BuildGraphPath=%BuildLogs%\z0.%ProjectId%.dg.json
set ZLibProj=%SlnRoot%\lib\z0.lib.csproj
set TestSln=%SlnRoot%\test\z0.test.sln
set CgRoot=%ZDev%\codegen
set CgSln=%CgRoot%\z0.codegen.sln
set CgProjectPath=%CgRoot%\%ProjectId%\%ProjectFile%
set ZSln=%SlnRoot%\z0.sln
set BuildPlatform="Any CPU"
set ZLibBuildLog=%BuildLogs%\z0.lib.log
set TestBuildLog=%BuildLogs%\z0.test.log
set AppsBuildLog=%BuildLogs%\z0.apps.log
set BuildBinRoot=%ZDev%\.build\bin
set ProjectBuildRoot=%BuildBinRoot%\z0.%ProjectId%\%BuildKind%\%FrameworkMoniker%
set ZPackNugetDir=%ZPack%\nuget
set BuildLogPath="%BuildLogs%\z0.%ProjectId%.log"
set BuildProps=/p:Configuration=%BuildKind% /p:Platform=%BuildPlatform%
set LibDeployRoot=%ZLibs%\z0.%ProjectId%
set LibDeployDir=%LibDeployRoot%\%FrameworkMoniker%

set BuildLibsCmd=dotnet build %ZLibProj% %BuildProps% -fl -flp:logfile=%ZLibBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildTestCmd=dotnet build %TestSln% %BuildProps% -fl -flp:logfile=%TestBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgSlnCmd=dotnet build %CgSln% %BuildProps% -fl -flp:logfile=%BuildLogPath%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildAppsCmd=dotnet build %ZSln% %BuildProps% -fl -flp:logfile=%AppsBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgProjectCmd=dotnet build %CgProjectPath% %BuildProps% -fl -flp:logfile=%BuildLogPath%;verbosity=%BuildVerbosity% -graph:true -m:24

