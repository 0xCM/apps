@echo off
call %~dp0config.cmd
set SlnDir=%TopDir%
set SlnName=z0.sln
call %~dp0sln-config.cmd

call %~dp0sln-add-libs.cmd

call %SlnCmdShellCmd%
call %SlnXedShellCmd%
call %SlnCgShellCmd%
call %SlnIntelShellCmd%

@REM dotnet sln %SlnPath% add %TopDir%/deprecated/z0.deprecated.csproj
@REM dotnet sln %SlnPath% add %TopDir%/expr/z0.expr.csproj
@REM dotnet sln %SlnPath% add %TopDir%/lang/z0.lang.csproj
@REM dotnet sln %SlnPath% add %TopDir%/extract/z0.extract.csproj
@REM dotnet sln %SlnPath% add %TopDir%/rules/z0.rules.csproj

@REM dotnet sln %SlnPath% add %AppDir%/glue/z0.glue.csproj
@REM dotnet sln %SlnPath% add %AppDir%/llvm.tools/z0.llvm.tools.csproj


dotnet sln %SlnPath% add %TestDir%/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %TestDir%/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %TestDir%/test.shell/z0.test.shell.csproj
