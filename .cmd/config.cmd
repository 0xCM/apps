@echo off

set BuildPlatform="Any CPU"
set FrameworkMoniker=net6.0
set TargetFramework=%FrameworkMoniker%
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildProps=/p:Configuration=%BuildKind% /p:Platform=%BuildPlatform%

set ProjectSlnFile=z0.%ProjectId%.sln
set SlnRoot=%~dp0..
set CgRoot=%SlnRoot%\cg
set ShellRoot=%SlnRoot%\shells
set LibsRoot=%SlnRoot%\libs
set TestRoot=%SlnRoot%\test
set LibsWs=%LibsRoot%
set LibWs=%SlnRoot%\libs\%WsId%
set LibSlnPath=%LibWs%\%WsId%.sln

set WsBuild=%SlnRoot%\.build
set WsLogs=%WsBuild%\logs
set WsBin=%WsBuild%\bin
set WsObj=%WsBuild%\obj
set TestLog=%WsLogs%\z0.%ProjectId%.tests.trx
set BuildLogs=%WsLogs%

set BuildTool=dotnet build
set SlnTool=dotnet sln

set SlnFile=%WsId%.sln
set SlnPath=%SlnRoot%\%WsArea%\%WsId%\%SlnFile%
set SlnLog=%WsLogs%\%SlnId%.build.log
set BuildSln=%BuildTool% %SlnPath% %BuildProps% -fl -flp:logfile=%SlnLog%;verbosity=%BuildVerbosity% -graph:true -m:24

mkdir %WsLogs% 1>nul 2>nul
set BuldLogs=%WsLogs%

set ImportDefs=%SlnRoot%\props\
set AppSettings=%ImportDefs%app.settings.csv
set ControlScripts=%Views%\control\.cmd

set RepoArchives=%Views%\archives\repos
set RepoArchive=%RepoArchives%\%WsId%.repo.archive.zip
set CommitLog=%Views%\db\logs\%WsId%.commit.log

set FrameworkBuildRoot=%WsBin%\z0.%ProjectId%\%BuildKind%\%TargetFramework%
set ShellBin=%FrameworkBuildRoot%\%RuntimeMoniker%\%ShellName%
set BuildLog=%BuildLogs%\z0.%ProjectId%.build.log
set SlnBuildLog=%BuildLogs%\z0.%SlnId%.build.log

set ShellName=%ShellId%.exe
set ShellExePath=%FrameworkBuildRoot%\%RuntimeMoniker%\%ShellName%
set DllShellBin=%FrameworkBuildRoot%
set DllShellPath=%DllShellBin%\z0.%ProjectId%.exe

set LibName=z0.%ProjectId%.dll
set LibPath=%FrameworkBuildRoot%\%LibName%

set LibProjectRoot=%LibsRoot%\%ProjectId%
set CsProjectFile=z0.%ProjectId%.csproj
set CsProjectPath=%LibProjectRoot%\%CsProjectFile%
set LibProject=%LibProjectRoot%\%CsProjectFile%
set LibWsFile=%LibProjectRoot%\%ProjectId%.code-workspace
set BuildLib=%BuildTool% %CsProjectPath% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildLibs=%BuildTool% %LibsRoot%\z0.libs.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ProjectPath=%SlnRoot%\%WsArea%\%WsId%\%CsProjectFile%
set BuildProject=%BuildTool% %ProjectPath% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ShellProject=%ShellRoot%\%ProjectId%\%CsProjectFile%
set BuildShell=%BuildTool% %ShellProject% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set AreaShellProject=%SlnRoot%\%Area%\%ProjectId%\%CsProjectFile%
set BuildAreaShell=%BuildTool% %AreaShellProject% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set WsShellProject=%SlnRoot%\%WsArea%\%WsId%\%CsProjectFile%
set BuildWsShell=%BuildTool% %WsShellProject% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set shell=%WsBin%\z0.%ProjectId%\%BuildKind%\%TargetFramework%\%RuntimeMoniker%\%ShellName%

set TestSln=%TestRoot%\z0.test.sln
set TestBuildLog=%BuildLogs%\z0.test.build.log
set BuildTests=%BuildTool% %TestSln% %BuildProps% -fl -flp:logfile=%TestBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set ztest=%WsBin%\z0.test.shell\%BuildKind%\%TargetFramework%\%RuntimeMoniker%\ztest.exe

set BuildCgShell=%BuildTool% %CgRoot%\cg.shell\z0.cg.shell.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgIntel=%BuildTool% %CgRoot%\cg.intel\z0.cg.intel.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgCommon=%BuildTool% %CgRoot%\cg.common\z0.cg.common.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgIntel=%BuildTool% %CgRoot%\cg.intel\z0.cg.intel.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgLlvm=%BuildTool% %CgRoot%\cg.xed\z0.cg.llvm.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCg=%BuildTool% %CgRoot%\cg.libs\z0.cg.libs.csproj %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgSln=%BuildTool% %CgRoot%\z0.cg.sln %BuildProps% -fl -flp:logfile=%SlnBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set MainSln=%SlnRoot%\z0.sln
set BuildMain=%BuildTool% %MainSln% %BuildProps% -fl -flp:logfile=%SlnBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ModelWs=%SlnRoot%\models
set ModelProject=%ModelWs%\z0.models.csproj
set BuildModels=%BuildTool% %ModelProject% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set CmdShellRoot=%SlnRoot%\cmd
set CmdProject=%CmdShellRoot%\z0.cmd.csproj
set BuildCmdShell=%BuildTool% %CmdProject% %BuildProps% -fl -flp:logfile=%BuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set CmdShellPath=%FrameworkBuildRoot%\%RuntimeMoniker%\%ShellName%

set SlnLibs=%SlnRoot%/libs
set SlnShells=%SlnRoot%/shells
set SlnCg=%SlnRoot%/cg
set SlnTests=%SlnRoot%/test

set ZCmdDir=%WsBin%\z0.cmd\%BuildKind%\%TargetFramework%\%RuntimeMoniker%
set zcmd=%ZCmdDir%\zcmd.exe
set zcmd-pub=%WsBin%\z0.cmd\%BuildKind%\%TargetFramework%\%RuntimeMoniker%\publish\zcmd.exe

set CleanBin=rmdir %WsBin% /s/q
set CleanObj=rmdir %WsObj% /s/q
set CleanBuild=rmdir %WsBuild% /s/q

set AddSln=%~dp0sln-add.cmd

set PublishShell=dotnet publish %CmdProject%