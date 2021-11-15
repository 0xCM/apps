@echo off
call %~dp0config.cmd
set CmdSpec=dotnet build %SlnPath% -c Release
call %CmdSpec%