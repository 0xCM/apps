@echo off
set ShellDir=%~dp0..\
set AppDir=%~dp0..\..\
set TopDir=%~dp0..\..\..\
set SlnName = z0.xed.shell.sln
set SlnPath=%ShellDir%%SlnName%
dotnet sln %SlnPath% add %ShellDir%z0.xed.shell.csproj
dotnet sln %SlnPath% add %AppDir%/asm.core/z0.asm.core.csproj
dotnet sln %SlnPath% add %AppDir%/asm.operands/z0.asm.operands.csproj
dotnet sln %SlnPath% add %AppDir%/intel.core/z0.intel.core.csproj
dotnet sln %SlnPath% add %AppDir%/intel.intrinsics/z0.intel.intrinsics.csproj
dotnet sln %SlnPath% add %AppDir%/apps.core/z0.apps.core.csproj

dotnet sln %SlnPath% add %TopDir%/bits/z0.bits.csproj
dotnet sln %SlnPath% add %TopDir%/alloc/z0.alloc.csproj
dotnet sln %SlnPath% add %TopDir%/archives/z0.archives.csproj
dotnet sln %SlnPath% add %TopDir%/numbers/z0.numbers.csproj
dotnet sln %SlnPath% add %TopDir%/lines/z0.lines.csproj
dotnet sln %SlnPath% add %TopDir%/codegen/codegen.intel/z0.codegen.intel.csproj
