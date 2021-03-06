@echo off
set WsId=z0
call %~dp0config.cmd

set SlnPath=%SlnRoot%/z0.sln

dotnet sln %SlnPath% add %SlnRoot%/cmd/z0.cmd.csproj

dotnet sln %SlnPath% add %SlnCg%/cg.libs/z0.cg.libs.csproj
dotnet sln %SlnPath% add %SlnCg%/cg.shell/z0.cg.shell.csproj

dotnet sln %SlnPath% add %SlnLibs%/cmd.checks/z0.cmd.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/llvm.checks/z0.llvm.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/queues.checks/z0.queues.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/containers.checks/z0.containers.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/memory.checks/z0.memory.checks.csproj

dotnet sln %SlnPath% add %SlnLibs%/clr.checks/z0.clr.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/api.checks/z0.api.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/asm.checks/z0.asm.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/sos.checks/z0.sos.checks.csproj

dotnet sln %SlnPath% add %SlnShells%/ws.checks/z0.ws.checks.csproj
dotnet sln %SlnPath% add %SlnShells%/calcs.check/z0.calcs.check.csproj
dotnet sln %SlnPath% add %SlnShells%/intel/z0.intel.csproj

dotnet sln %SlnPath% add %SlnTests%/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %SlnTests%/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %SlnTests%/test.shell/z0.test.shell.csproj

