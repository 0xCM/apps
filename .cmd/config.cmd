@echo off

set BuildPlatform="Any CPU"
set FrameworkMoniker=net6.0
set TargetFramework=%FrameworkMoniker%
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildProps=/p:Configuration=%BuildKind% /p:Platform=%BuildPlatform%

set ProjectSlnFile=z0.%ProjectId%.sln
set CsProjectFile=z0.%ProjectId%.csproj
set LibName=z0.%ProjectId%.dll

set SlnRoot=%DevRoot%\dev\z0
set CgRoot=%SlnRoot%\cg
set ShellRoot=%SlnRoot%\shells
set TestRoot=%SlnRoot%\test
set LibWs=%SlnRoot%\libs
set LibSlnPath=%LibWs%\%WsId%.sln
set AreaRoot=%SlnRoot%\%Area%
set SlnScripts=%SlnRoot%\.cmd

set WsBuild=%SlnRoot%\.build
set WsLogs=%WsBuild%\logs
set WsBin=%WsBuild%\bin
set WsObj=%WsBuild%\obj
set TestLog=%WsLogs%\z0.%ProjectId%.tests.trx
set BuildLogs=%WsLogs%
set BuildTool=dotnet build


set BuildLog=%BuildLogs%\z0.%ProjectId%.log
set SlnBuildLog=%BuildLogs%\z0.%SlnId%.log

set ImportDefs=%SlnRoot%\props\
set AppSettings=%ImportDefs%app.settings.csv

set ControlScripts=%Views%\control\.cmd

set RepoArchives=%Views%\archives\repos
set RepoArchive=%RepoArchives%\%WsId%.repo.archive.zip
set CommitLog=%Views%\db\logs\%WsId%.commit.log

set TargetBuildRoot=%WsBin%\z0.%ProjectId%\%BuildKind%\%TargetFramework%
set ShellBin=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%

set AreaSlnFile=z0.%WsId%.sln
set AreaSlnTxtLog=-fl -flp:logfile=%WsLogs%\z0.%SlnId%.log
set AreaSlnPath=%AreaRoot%\%WsId%\%AreaSlnFile%
set BuildAreaSln=%BuildTool% %AreaSlnPath% %BuildProps% %AreaSlnTxtLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set AreaProjectPath=%AreaRoot%\%ProjectId%\%CsProjectFile%
set AreaProjectLog=%WsLogs%\z0.%ProjectId%.log
set AreaProjectTxtLog=-fl -flp:logfile=%AreaProjectLog%
set BuildAreaProject=%BuildTool% %AreaProjectPath% %BuildProps% %AreaProjectTxtLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ShellName=%ShellId%.exe
set ShellExePath=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%
set DllShellBin=%TargetBuildRoot%
set DllShellPath=%DllShellBin%\z0.%ProjectId%.exe

set shell=%ShellExePath%
set dllshell=%DllShellPath%

set LibPath=%TargetBuildRoot%\%LibName%

set LibProject=%LibWs%\%ProjectId%
set CsProjectPath=%LibProject%\%CsProjectFile%
set BuildLib=%BuildTool% %CsProjectPath% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ProjectBinLogPath=%WsLogs%\z0.%ProjectId%.binlog
set ProjectBinLogSpec=-bl:%ProjectBinLogPath%


set CmdShellRoot=%SlnRoot%\cmd
set CmdProject=%CmdShellRoot%\z0.cmd.csproj
set CmdShellLog=%BinLogSpec%
set BuildCmdShell=%BuildTool% %CmdProject% %BuildProps% %ProjectBinLogSpec%; -graph:true -m:24
set CmdShellPath=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%

set SlnLibs=%SlnRoot%\libs
set SlnShells=%SlnRoot%\shells
set SlnCg=%SlnRoot%\cg
set SlnTests=%SlnRoot%\test

set ZCmdDir=%WsBin%\z0.cmd\%BuildKind%\%TargetFramework%\%RuntimeMoniker%
set zcmd=%ZCmdDir%\zcmd.exe
set zcmd-pub=%WsBin%\z0.cmd\%BuildKind%\%TargetFramework%\%RuntimeMoniker%\publish\zcmd.exe

set CleanBin=rmdir %WsBin% /s/q
set CleanObj=rmdir %WsObj% /s/q
set CleanBuild=rmdir %WsBuild% /s/q

set AddSln=%~dp0sln-add.cmd
set PublishShell=dotnet publish %CmdProject%

mkdir %BuildLogs% 1>nul 2>nul
