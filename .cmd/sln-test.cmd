@echo off
call %~dp0config.cmd

set Area=test
set SlnName=z0.%Area%.sln
set SlnPath=%SlnRoot%/%Area%/%SlnName%
echo SlnPath:%SlnPath%

dotnet sln %SlnPath% add %SlnRoot%/%Area%/test.checks/z0.%Area%.checks.csproj
dotnet sln %SlnPath% add %SlnRoot%/%Area%/test.units/z0.%Area%.units.csproj
dotnet sln %SlnPath% add %SlnRoot%/%Area%/test.shell/z0.%Area%.shell.csproj
