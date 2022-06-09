@echo off
call %~dp0config.cmd

set Area=lib
set SlnName=z0.%Area%.sln
set SlnPath=%SlnRoot%/%SlnName%
echo SlnPath:%SlnPath%

dotnet sln %SlnPath% add %SlnRoot%/%Area%/z0.%Area%.csproj
