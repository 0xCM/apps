@echo off
set WsId=z0
call %~dp0config.cmd

set SlnPath=%SlnRoot%/z0.sln

dotnet sln %SlnPath% add %SlnRoot%/cmd/z0.cmd.csproj

@REM dotnet sln %SlnPath% add %SlnCg%/cg.libs/z0.cg.libs.csproj
@REM dotnet sln %SlnPath% add %SlnCg%/cg.shell/z0.cg.shell.csproj

@REM dotnet sln %SlnPath% add %SlnLibs%/cmd.checks/z0.cmd.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/llvm.checks/z0.llvm.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/queues.checks/z0.queues.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/memory.checks/z0.memory.checks.csproj

@REM dotnet sln %SlnPath% add %SlnLibs%/clr.checks/z0.clr.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/api.checks/z0.api.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/asm.checks/z0.asm.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/sos.checks/z0.sos.checks.csproj
@REM dotnet sln %SlnPath% add %SlnLibs%/db.shell/z0.db.shell.csproj

@REM dotnet sln %SlnPath% add %SlnShells%/ws.checks/z0.ws.checks.csproj
@REM dotnet sln %SlnPath% add %SlnShells%/calcs.check/z0.calcs.check.csproj
@REM dotnet sln %SlnPath% add %SlnShells%/intel/z0.intel.csproj
@REM dotnet sln %SlnPath% add %SlnShells%/workers/z0.workers.csproj

@REM dotnet sln %SlnPath% add %SlnTests%/test.units/z0.test.units.csproj
@REM dotnet sln %SlnPath% add %SlnTests%/test.checks/z0.test.checks.csproj
@REM dotnet sln %SlnPath% add %SlnTests%/test.shell/z0.test.shell.csproj

