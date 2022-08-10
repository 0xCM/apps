@echo off

set SlnId=z0
set SlnRoot=%~dp0
set Artifacts=%SlnRoot%artifacts
set SlnScripts=%SlnRoot%scripts
set Archives=%Views%\archives
set RepoArchives=%Archives%\repos
set RepoArchive=%RepoArchives%\%SlnId%.zip
set CommitLog=%RepoArchives%\%SlnId%.commit.log

set ZVersion=0.0.0.2
set BuildPlatform="Any CPU"
set FrameworkMoniker=net6.0
set TargetFramework=%FrameworkMoniker%
set BuildKind=Release
set RuntimeMoniker=win-x64
set BuildVerbosity=normal
set BuildProps=/p:Configuration=%BuildKind% /p:Platform=%BuildPlatform%

set ShellRoot=%SlnRoot%shells
set TestRoot=%SlnRoot%test
set LibRoot=%SlnRoot%libs
set ShellWs=%SlnRoot%shells
set AreaRoot=%SlnRoot%%Area%
set SlnPath=%AreaRoot%\z0.%Area%.sln
set BuildLogs=%Artifacts%\logs

set ProjectSlnFile=z0.%ProjectId%.sln
set CsProjectFile=z0.%ProjectId%.csproj
set LibName=z0.%ProjectId%.dll

set CgRoot=%SlnRoot%cg

set WsBin=%Artifacts%\bin
set TestLog=%BuildLogs%\z0.%ProjectId%.tests.trx
set BuildTool=dotnet build
set PublishTool=dotnet publish -c %BuildKind%
set PackageTool=dotnet pack --include-symbols --include-source

set RootSlnLogPath=%BuildLogs%\z0.sln.binlog
set RootSlnLogSpec=-bl:%RootSlnLogPath%

set RootSlnPath=%SlnRoot%\z0.sln
set SlnRootPath=%SlnRoot%\z0.sln
set PublishCmd=%PublishTool% %RootSlnPath%
set BuildLog=%BuildLogs%\z0.%ProjectId%.log
set SlnBuildLog=%BuildLogs%\z0.%SlnId%.log

set BinLogPath=%BuildLogs%\z0.%ProjectId%.binlog
set BinLogSpec=-bl:%BinLogPath%

set ImportDefs=%SlnRoot%\props\
set AppSettings=%ImportDefs%app.settings.csv

set ControlScripts=%Views%\control\.cmd

set BuildOptions=-graph:true -m:24
set ProjectHome=%SlnRoot%\%Area%\%ProjectId%
set ProjectPath=%ProjectHome%\z0.%ProjectId%.csproj
set ProjectSln=%ProjectHome%\z0.%ProjectId%.sln
set BuildProject=%BuildTool% %ProjectPath% %BuildProps% %BinLogSpec%; %BuildOptions%
set BuildSln=%BuildTool% %SlnPath% %BuildProps% %BinLogSpec%; %BuildOptions%
set BuildProjectSln=%BuildTool% %ProjectSln% %BuildProps% %BinLogSpec%; %BuildOptions%
set PublishProject=%PublishTool%
set PackageProject=%PackageTool% %ProjectPath%
set PackageSln=%PackageTool% %ProjectSln%
set PublishSln=%PublishTool% %ProjecSln%

set TargetBuildRoot=%WsBin%\z0.%ProjectId%\%BuildKind%\%TargetFramework%
set ShellBin=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%

set BuildSlnRoot=%BuildTool% %RootSlnPath% %BuildProps% %RootSlnLogSpec%; %BuildOptions%

set ShellName=%ShellId%.exe
set ShellExePath=%TargetBuildRoot%\%RuntimeMoniker%\%ShellName%
set DllShellBin=%TargetBuildRoot%
set DllShellPath=%DllShellBin%\z0.%ProjectId%.exe

set shell=%ShellExePath%
set dllshell=%DllShellPath%

set LibPath=%TargetBuildRoot%\%LibName%
set LibProject=%LibRoot%\%ProjectId%
set CsProjectPath=%LibProject%\%CsProjectFile%
set BuildLib=%BuildTool% %CsProjectPath% %BuildProps% %BinLogSpec%; %BuildOptions%

set CmdShellRoot=%SlnRoot%\cmd
set CmdProject=%CmdShellRoot%\z0.cmd.csproj
set CmdShellLog=%BinLogSpec%
set BuildCmdShell=%BuildTool% %CmdProject% %BuildProps% %BinLogSpec%; %BuildOptions%
set ShellArtifacts=%TargetBuildRoot%\%RuntimeMoniker%
set ShellPath=%ShellArtifacts%\%ShellId%.exe

set SlnLibs=%SlnRoot%\libs
set SlnShells=%SlnRoot%\shells
set SlnCg=%SlnRoot%\cg
set SlnTests=%SlnRoot%\test

set ZCmdDir=%WsBin%\z0.cmd\%BuildKind%\%TargetFramework%\%RuntimeMoniker%
set zcmd=%ZCmdDir%\zcmd.exe
set zcmd-pub=%WsBin%\z0.cmd\%BuildKind%\%TargetFramework%\%RuntimeMoniker%\publish\zcmd.exe

set CleanBuild=rmdir %Artifacts% /s/q

set AddSln=%~dp0sln-add.cmd

set PubRoot=%Views%\tools\z0
set ShellPubRoot=%PubRoot%\%ShellId%
set PublishShell=dotnet publish %ProjectPath% --output %ShellPubRoot%

mkdir %BuildLogs% 1>nul 2>nul
