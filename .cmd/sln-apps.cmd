@echo off
call %~dp0config.cmd

set Area=apps
set SlnName=z0.%Area%.sln
set SlnPath=%SlnRoot%/%Area%/%SlnName%
echo SlnPath:%SlnPath%

dotnet sln %SlnPath% add %TopDir%/alloc/z0.alloc.csproj
dotnet sln %SlnPath% add %TopDir%/archives/z0.archives.csproj
dotnet sln %SlnPath% add %TopDir%/bits/z0.bits.csproj
dotnet sln %SlnPath% add %TopDir%/diagnostics/z0.diagnostics.csproj
dotnet sln %SlnPath% add %TopDir%/expr/z0.expr.csproj
dotnet sln %SlnPath% add %TopDir%/extract/z0.extract.csproj
dotnet sln %SlnPath% add %TopDir%/lines/z0.lines.csproj
dotnet sln %SlnPath% add %TopDir%/numbers/z0.numbers.csproj

dotnet sln %SlnPath% add %CgDir%/codegen.intel/z0.codegen.intel.csproj
dotnet sln %SlnPath% add %CgDir%/codegen.common/z0.codegen.common.csproj
dotnet sln %SlnPath% add %CgDir%/codegen.llvm/z0.codegen.llvm.csproj

dotnet sln %SlnPath% add %AppDir%/apps.core/z0.apps.core.csproj
dotnet sln %SlnPath% add %AppDir%/asm/z0.asm.csproj
dotnet sln %SlnPath% add %AppDir%/asm.core/z0.asm.core.csproj
dotnet sln %SlnPath% add %AppDir%/asm.operands/z0.asm.operands.csproj
dotnet sln %SlnPath% add %AppDir%/asm.prototypes/z0.asm.prototypes.csproj
dotnet sln %SlnPath% add %AppDir%/asm.services/z0.asm.services.csproj
dotnet sln %SlnPath% add %AppDir%/capture/z0.capture.csproj
dotnet sln %SlnPath% add %AppDir%/cmd.actions/z0.cmd.actions.csproj
dotnet sln %SlnPath% add %AppDir%/intel.core/z0.intel.core.csproj
dotnet sln %SlnPath% add %AppDir%/intel.intrinsics/z0.intel.intrinsics.csproj
dotnet sln %SlnPath% add %AppDir%/glue/z0.glue.csproj
dotnet sln %SlnPath% add %AppDir%/llvm.tools/z0.llvm.tools.csproj
dotnet sln %SlnPath% add %AppDir%/machines.X86/z0.machines.x86.csproj
dotnet sln %SlnPath% add %AppDir%/cmd.shell/z0.cmd.shell.csproj
dotnet sln %SlnPath% add %AppDir%/xed.shell/z0.xed.shell.csproj
