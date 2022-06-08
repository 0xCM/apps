@echo off
set BuildPlatform="Any CPU"
set FrameworkMoniker=net6.0
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildProps=/p:Configuration=%BuildKind% /p:Platform=%BuildPlatform%

set TopDir=%ZDev%
set SlnRoot=%TopDir%
set Archives=%ZArchive%
set ArchiveRoot=%ZArchive%
set RepoArchives=%ArchiveRoot%\bin\source
set CmdScripts=%TopDir%\.cmd

set AppDir=%TopDir%\apps
set TestDir=%TopDir%\test
set CgDir=%TopDir%\codegen
set LibDir=%TopDir%\lib
set LibsRoot=%TopDir%\libs
set ShellRoot=%SlnRoot%\shells

set BuildRoot=%SlnRoot%\.build
set BuildBinRoot=%BuildRoot%\bin

set RepoLogs=%Archives%\repos
mkdir %RepoLogs% 1>nul 2>nul

set EtlLogs=%Archives%\etl
mkdir %EtlLogs% 1>nul 2>nul

set BuildLogs=%BuildRoot%\logs
mkdir %BuildLogs% 1>nul 2>nul

set CmdLogs=%BuildLogs%
mkdir %CmdLogs% 1>nul 2>nul

set ProjectFile=z0.%ProjectId%.csproj
set ShellName=%ShellId%.exe
set LibName=z0.%ProjectId%.dll

set CmdLog=%CmdLogs%\z0.cmd.log
set ProjectBuildRoot=%BuildBinRoot%\z0.%ProjectId%\%BuildKind%\%FrameworkMoniker%
set ShellBin=%ProjectBuildRoot%\%RuntimeMoniker%
set LibPath=%ProjectBuildRoot%\%LibName%
set ShellPath=%ShellBin%\%ShellName%
set ProjectDir=%TopDir%\%ProjectId%
set ProjectSlnName=z0.%ProjectId%.sln
set ProjectSlnPath=%ProjectDir%\%ProjectSlnName%

set ProjectBinLog=%BuildLogs%\z0.%ProjectId%.build.bin
set ProjectBuildLog=%BuildLogs%\z0.%ProjectId%.build.log
set ProjectGraphPath=%BuildLogs%\z0.%ProjectId%.dg.json
set ProjectBuildLogPath="%BuildLogs%\z0.%ProjectId%.log"
set TargetSpec=%SlnRoot%\apps\%ProjectId%\%ProjectFile%
set BuildAppLibCmd=dotnet build %TargetSpec% %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
echo BuildAppLibCmd:%BuildAppLibCmd% > %CmdLog%

set TargetSpec=%SlnRoot%\%ProjectId%\%ProjectFile%
set BuildRootProjectCmd=dotnet build %TargetSpec% %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
echo BuildRootProjectCmd:%BuildRootProjectCmd% >> %CmdLog%

set Area=apps
set AreaSln=%SlnRoot%\%Area%\z0.%Area%.sln
set AreaBuildLog=%BuildLogs%\z0.%Area%.build.log
set AreaBuildCmd=dotnet build %AreaSln% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildAppsCmd=%AreaBuildCmd%
echo BuildAppsCmd:%BuildAppsCmd% >> %CmdLog%

set Area=libs
set AreaProject=%SlnRoot%\%Area%\%ProjectId%\z0.%ProjectId%.csproj
set AreaBuildLog=%BuildLogs%\z0.%ProjectId%.build.log
set AreaBuildCmd=dotnet build %AreaProject% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildLibsCmd=%AreaBuildCmd%

set Area=test
set AreaSln=%SlnRoot%\%Area%\z0.%Area%.sln
set AreaBuildLog=%BuildLogs%\z0.%Area%.build.log
set AreaBuildCmd=dotnet build %AreaSln% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildTestsCmd=%AreaBuildCmd%
echo BuildTestsCmd:%BuildTestsCmd% >> %CmdLog%

set Area=lib
set AreaProject=%SlnRoot%\%Area%\z0.%Area%.csproj
set AreaBuildLog=%BuildLogs%\z0.%Area%.build.log
set AreaBuildCmd=dotnet build %AreaProject% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildZlibCmd=%AreaBuildCmd%
echo BuildZlibCmd:%BuildLibCmd% >> %CmdLog%

set Area=codegen
set AreaSln=%SlnRoot%\%Area%\z0.%Area%.sln
set AreaBuildLog=%BuildLogs%\z0.%Area%.build.log
set BuildAreaCmd=dotnet build %AreaSln% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgCmd=%BuildAreaCmd%
echo BuildCgCmd:%BuildCgCmd% >> %CmdLog%

set _AreaProject=%TopDir%\%AreaId%\%ProjectId%\z0.%ProjectId%.csproj
set _AreaBuildLog=%BuildLogs%\z0.%AreaId%.build.log
set _AreaBuildCmd=dotnet build %_AreaProject% %BuildProps% -fl -flp:logfile=%_AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set _AreaExePath=%BuildBinRoot%\%Area%\z0.%ProjectId%\%BuildKind%\%FrameworkMoniker%\%RuntimeMoniker%\z0.%ProjectId%.exe

set ShellProject=%SlnRoot%\%Area%\%ProjectId%\z0.%ProjectId%.csproj
set ShellBuildLog=%BuildLogs%\z0.%ProjectId%.build.log
set BuildCgShellCmd=dotnet build %ShellProject% %BuildProps% -fl -flp:logfile=%ShellBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
echo BuildCgShellCmd:%BuildCgShellCmd% >> %CmdLog%

set Area=z0
set AreaSln=%SlnRoot%\%Area%.sln
set AreaBuildLog=%BuildLogs%\%Area%.main.build.log
set BuildAreaCmd=dotnet build %AreaSln% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildMainCmd=%BuildAreaCmd%
echo BuildMainCmd:%BuildMainCmd% >> %CmdLog%

set Area=shells
set AreaProject=%SlnRoot%\%Area%\%ProjectId%\z0.%ProjectId%.csproj
set AreaBuildLog=%BuildLogs%\z0.%ProjectId%.build.log
set AreaBuildCmd=dotnet build %AreaProject% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildAreaShellCmd=%AreaBuildCmd%

set ShellProject=%SlnRoot%\%ProjectId%\z0.%ProjectId%.csproj
set ShellBuildLog=%BuildLogs%\z0.%ProjectId%.build.log
set BuildShellCmd=dotnet build %ShellProject% %BuildProps% -fl -flp:logfile=%ShellBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
echo BuildShellCmd:%BuildShellCmd% >> %CmdLog%

set Area=%ProjectId%
set AreaSln=%SlnRoot%\%ProjectId%\z0.%Area%.sln
set AreaBuildLog=%BuildLogs%\%Area%.main.build.log
set BuildAreaCmd=dotnet build %AreaSln% %BuildProps% -fl -flp:logfile=%AreaBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildProjectSlnCmd=%BuildAreaCmd%
echo BuildProjectSlnCmd:%BuildProjectSlnCmd% >> %CmdLog%

set CmdProject=%SlnRoot%\cmd\z0.cmd.csproj
set CmdSln=%SlnRoot%\cmd\z0.cmd.sln
set CmdBuildLog=%BuildLogs%\z0.cmd.build.log
set BuildCmdSln=dotnet build %CmdSln% %BuildProps% -fl -flp:logfile=%CmdBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
echo BuildCmdCmd:%BuildCmdCmd% >> %CmdLog%

set DeploySrc=%ShellBin%
set DeployLog=%EtlLogs%\deploy-%ProjectId%.log
set DeployDst=%ZBin%
set DeployCmd=robocopy %DeploySrc% %DeployDst% /log:%DeployLog% /tee /TS /BYTES /V /e


echo DeploySrc:%DeploySrc% > %DeployLog%
echo DeployDst:%DeployDst% >> %DeployLog%
echo DeployCmd:%DeployCmd% >> %DeployLog%