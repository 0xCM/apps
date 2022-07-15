@echo off
set WsId=z0
call %~dp0config.cmd

set SlnPath=%SlnRoot%/z0.sln
set LibWs=%SlnRoot%/libs

dotnet sln %SlnPath% add %LibWs%/z0.libs.csproj
dotnet sln %SlnPath% add %SlnRoot%/cmd/z0.cmd.csproj

dotnet sln %SlnPath% add %CgRoot%/cg.libs/z0.cg.libs.csproj
dotnet sln %SlnPath% add %CgRoot%/cg.shell/z0.cg.shell.csproj

dotnet sln %SlnPath% add %LibWs%/api.checks/z0.api.checks.csproj
dotnet sln %SlnPath% add %LibWs%/asm.checks/z0.asm.checks.csproj

dotnet sln %SlnPath% add %LibWs%/cmd.checks/z0.cmd.checks.csproj
dotnet sln %SlnPath% add %LibWs%/llvm.checks/z0.llvm.checks.csproj
dotnet sln %SlnPath% add %LibWs%/queues.checks/z0.queues.checks.csproj
dotnet sln %SlnPath% add %LibWs%/containers.checks/z0.containers.checks.csproj
dotnet sln %SlnPath% add %LibWs%/memory.checks/z0.memory.checks.csproj

dotnet sln %SlnPath% add %LibWs%/clr.checks/z0.clr.checks.csproj
dotnet sln %SlnPath% add %LibWs%/api.checks/z0.api.checks.csproj
dotnet sln %SlnPath% add %LibWs%/asm.checks/z0.asm.checks.csproj
dotnet sln %SlnPath% add %LibWs%/sos.checks/z0.sos.checks.csproj
dotnet sln %SlnPath% add %LibWs%/cli/z0.cli.csproj

dotnet sln %SlnPath% add %SlnRoot%/shells/calcs.check/z0.calcs.check.csproj
dotnet sln %SlnPath% add %SlnRoot%/shells/intel/z0.intel.csproj

dotnet sln %SlnPath% add %SlnRoot%/test/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %SlnRoot%/test/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/test/test.shell/z0.test.shell.csproj

