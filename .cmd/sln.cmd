@echo off
set SlnName=z0.sln
call %~dp0config.cmd

set SlnTool=dotnet sln
set SlnRoot=%DevRoot%\dev\z0
set SlnPath=%SlnRoot%\z0.sln
set LibsRoot=%SlnRoot%/libs
dotnet sln %SlnPath% add %LibsRoot%/z0.libs.csproj
dotnet sln %SlnPath% add %LibsRoot%/llvm.checks/z0.llvm.checks.csproj
dotnet sln %SlnPath% add %LibsRoot%/queues.checks/z0.queues.checks.csproj
dotnet sln %SlnPath% add %LibsRoot%/containers.checks/z0.containers.checks.csproj
dotnet sln %SlnPath% add %LibsRoot%/memory.checks/z0.memory.checks.csproj

dotnet sln %SlnPath% add %LibsRoot%/asm.checks/z0.asm.checks.csproj

dotnet sln %SlnPath% add %SlnRoot%/cmd/z0.cmd.csproj

dotnet sln %SlnPath% add %SlnRoot%/shells/calcs.check/z0.calcs.check.csproj
dotnet sln %SlnPath% add %SlnRoot%/shells/intel/z0.intel.csproj
dotnet sln %SlnPath% add %SlnRoot%/shells/workers/z0.workers.csproj

dotnet sln %SlnPath% add %SlnRoot%/test/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %SlnRoot%/test/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/test/test.shell/z0.test.shell.csproj
dotnet sln %SlnPath% add %SlnRoot%/cg/cg.libs/z0.cg.libs.csproj
