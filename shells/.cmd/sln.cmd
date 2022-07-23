@echo off
call %~dp0config.cmd
dotnet sln %SlnPath% add %SlnRoot%calcs.check\z0.calcs.check.csproj
dotnet sln %SlnPath% add %SlnRoot%intel\z0.intel.csproj
dotnet sln %SlnPath% add %SlnRoot%workers\z0.workers.csproj
dotnet sln %SlnPath% add %SlnRoot%ws.checks\z0.ws.checks.csproj