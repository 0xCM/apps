@echo off
call %~dp0config.cmd
set SlnDir=%TopDir%
set SlnName=z0.sln
call %~dp0sln-config.cmd

call %SlnLibCmd%
call %SlnAllocCmd%
call %SlnApiCodeCmd%
call %SlnArchivesCmd%
call %SlnAssetsCmd%
call %SlnBitsCmd%
call %SlnCommandsCmd%
call %SlnSymbolsCmd%
call %SlnNumbersCmd%
call %SlnDiagnosticsCmd%
call %SlnXedShellCmd%
call %SlnAsmOperandsCmd%
call %SlnAsmCoreCmd%
call %SlnIntelCoreCmd%
call %SlnIntelIntrinsicsCmd%
call %SlnIntelXedCmd%
call %SlnCmdActionsCmd%

call %SlnAsmPrototypesCmd%
call %SlnAsmServicesCmd%
call %SlnAsmCmd%


dotnet sln %SlnPath% add %TopDir%/deprecated/z0.deprecated.csproj
dotnet sln %SlnPath% add %TopDir%/expr/z0.expr.csproj
dotnet sln %SlnPath% add %TopDir%/lang/z0.lang.csproj
dotnet sln %SlnPath% add %TopDir%/extract/z0.extract.csproj
dotnet sln %SlnPath% add %TopDir%/rules/z0.rules.csproj


dotnet sln %SlnPath% add %AppDir%/capture/z0.capture.csproj
dotnet sln %SlnPath% add %AppDir%/glue/z0.glue.csproj
dotnet sln %SlnPath% add %AppDir%/llvm.tools/z0.llvm.tools.csproj
dotnet sln %SlnPath% add %AppDir%/machines.X86/z0.machines.x86.csproj

dotnet sln %SlnPath% add %CgDir%/codegen.intel/z0.codegen.intel.csproj
dotnet sln %SlnPath% add %CgDir%/codegen.common/z0.codegen.common.csproj
dotnet sln %SlnPath% add %CgDir%/codegen.llvm/z0.codegen.llvm.csproj
dotnet sln %SlnPath% add %CgDir%/codegen.shell/z0.codegen.shell.csproj

dotnet sln %SlnPath% add %TestDir%/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %TestDir%/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %TestDir%/test.shell/z0.test.shell.csproj
