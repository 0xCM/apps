@echo off
set WsId=z0
call %DevRoot%\dev\z0\.cmd\config.cmd
set SlnRoot=%DevRoot%/dev/z0/libs
set SlnPath=%SlnRoot%/z0.shells.sln

: dotnet sln %SlnPath% add %SlnRoot%/cmd/z0.cmd.csproj

: dotnet sln %SlnPath% add %SlnCg%/cg.libs/z0.cg.libs.csproj
: dotnet sln %SlnPath% add %SlnCg%/cg.shell/z0.cg.shell.csproj

dotnet sln %SlnPath% add %SlnRoot%/cmd.checks/z0.cmd.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/llvm.checks/z0.llvm.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/queues.checks/z0.queues.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/containers.checks/z0.containers.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/memory.checks/z0.memory.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/clr.checks/z0.clr.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/api.checks/z0.api.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/asm.checks/z0.asm.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/sos.checks/z0.sos.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/db.shell/z0.db.shell.csproj

: dotnet sln %SlnPath% add %SlnShells%/ws.checks/z0.ws.checks.csproj
: dotnet sln %SlnPath% add %SlnShells%/calcs.check/z0.calcs.check.csproj
: dotnet sln %SlnPath% add %SlnShells%/intel/z0.intel.csproj
: dotnet sln %SlnPath% add %SlnShells%/workers/z0.workers.csproj

: dotnet sln %SlnPath% add %SlnTests%/test.units/z0.test.units.csproj
: dotnet sln %SlnPath% add %SlnTests%/test.checks/z0.test.checks.csproj
: dotnet sln %SlnPath% add %SlnTests%/test.shell/z0.test.shell.csproj
: dotnet sln %SlnPath% add %SlnTests%/test.shell/z0.test.shell.csproj
