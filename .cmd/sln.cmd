@echo off
call %~dp0config.cmd
set SlnDir=%TopDir%
set SlnName=z0.sln
call %~dp0sln-config.cmd

call %~dp0sln-add-libs.cmd

call %SlnLibCmd%
call %SlnCmdShellCmd%
call %SlnXedShellCmd%
call %SlnCgShellCmd%
call %SlnIntelShellCmd%


dotnet sln %SlnPath% add %TestDir%/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %TestDir%/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %TestDir%/test.shell/z0.test.shell.csproj
