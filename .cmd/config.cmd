@echo off

set WsRoot=%DevRoot%\dev\z0
set SlnRoot=%WsRoot%

call %DevRoot%\control\.cmd\config.cmd
call %ControlScripts%\config-build.cmd

set LibsRoot=%WsRoot%\libs
set LibProject=%LibsRoot%\%ProjectId%\%CsProjectFile%
set BuildLib=dotnet build %LibProject% %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildLibs=dotnet build %LibsRoot%\z0.libs.csproj %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set SlnFile=z0.%SlnId%.sln
set SlnPath=%WsRoot%\%WsId%\%SlnFile%
set SlnBuildLog=%BuildLogs%\z0.%SlnId%.build.log
set BuildSln=dotnet build %SlnPath% %BuildProps% -fl -flp:logfile=%SlnBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ProjectPath=%WsRoot%\%WsArea%\%WsId%\%CsProjectFile%
set BuildProject=dotnet build %ProjectPath% %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set ShellRoot=%WsRoot%\shells
set ShellProject=%ShellRoot%\%ProjectId%\%CsProjectFile%
set BuildShell=dotnet build %ShellProject% %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24

set WsShellProject=%WsRoot%\%WsArea%\%WsId%\%CsProjectFile%
set BuildWsShell=dotnet build %WsShellProject% %BuildProps% -fl -flp:logfile=%ProjectBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set shell=%WsBin%\z0.%ProjectId%\%BuildKind%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellName%

set ZLibRoot=%WsRoot%\lib
set ZLibProject=%ZLibRoot%\z0.lib.csproj
set BuildZlib=dotnet build %ZLibProject% %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.lib.build.log;verbosity=%BuildVerbosity% -graph:true -m:24

set TestRoot=%WsRoot%\test
set TestSln=%TestRoot%\z0.test.sln
set TestBuildLog=%BuildLogs%\z0.test.build.log
set BuildTests=dotnet build %TestSln% %BuildProps% -fl -flp:logfile=%TestBuildLog%;verbosity=%BuildVerbosity% -graph:true -m:24
set ztest=%WsBin%\z0.test.shell\%BuildKind%\%FrameworkMoniker%\%RuntimeMoniker%\ztest.exe

set CgRoot=%WsRoot%\cg
set BuildCgShell=dotnet build %CgRoot%\cg.shell\z0.cg.shell.csproj %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cg.shell.build.log;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgIntel=dotnet build %CgRoot%\cg.intel\z0.cg.intel.csproj %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cg.intel.build.log;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgCommon=dotnet build %CgRoot%\cg.common\z0.cg.common.csproj %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cg.common.build.log;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgIntel=dotnet build %CgRoot%\cg.intel\z0.cg.intel.csproj %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cg.intel.build.log;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCgLlvm=dotnet build %CgRoot%\cg.xed\z0.cg.llvm.csproj %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cg.llvm.build.log;verbosity=%BuildVerbosity% -graph:true -m:24
set BuildCg=dotnet build %CgRoot%\cg.libs\z0.cg.libs.csproj %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cg.libs.build.log;verbosity=%BuildVerbosity% -graph:true -m:24

set MainSln=%WsRoot%\z0.sln
set BuildMain=dotnet build %MainSln% %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.build.log;verbosity=%BuildVerbosity% -graph:true -m:24

set CmdShellRoot=%WsRoot%\cmd
set CmdSln=%CmdShellRoot%\z0.cmd.sln
set BuildCmdSln=dotnet build %CmdSln% %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cmd.build.log;verbosity=%BuildVerbosity% -graph:true -m:24

set CmdProject=%WsRoot%\cmd\z0.cmd.csproj
set BuildCmdProject=dotnet build %CmdProject% %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.cmd.build.log;verbosity=%BuildVerbosity% -graph:true -m:24
set zcmd=%WsBin%\z0.cmd\%BuildKind%\%FrameworkMoniker%\%RuntimeMoniker%\zcmd.exe

set LiteralsRoot=%WsRoot%\literals
set LiteralsProject=%LiteralsRoot%\z0.literals.csproj
set BuildLiterals=dotnet build %LiteralsProject% %BuildProps% -fl -flp:logfile=%BuildLogs%\z0.literals.build.log;verbosity=%BuildVerbosity% -m:24

set CleanBin=rmdir %WsBin% /s/q
set CleanObj=rmdir %WsObj% /s/q
