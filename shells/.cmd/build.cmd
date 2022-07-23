@echo off
call %~dp0config.cmd
dotnet build %SlnPath% -c Release