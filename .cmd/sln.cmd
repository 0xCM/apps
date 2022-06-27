@echo off
set SlnName=z0.sln
call %~dp0config.cmd

set SlnTool=dotnet sln
set SlnRoot=%DevRoot%\dev\z0
set SlnPath=%SlnRoot%\z0.sln
set LibsRoot=%SlnRoot%/libs
dotnet sln %SlnPath% add %LibsRoot%/literals/z0.literals.csproj
dotnet sln %SlnPath% add %LibsRoot%/lib/z0.lib.csproj
dotnet sln %SlnPath% add %LibsRoot%/z0.libs.csproj
dotnet sln %SlnPath% add %SlnRoot%/cmd/z0.cmd.csproj
dotnet sln %SlnPath% add %SlnRoot%/test/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %SlnRoot%/test/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/cg/cg.libs/z0.cg.libs.csproj



