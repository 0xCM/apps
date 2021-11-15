@echo off
call %~dp0config.cmd
set CmdSpec=dotnet build %LibProjPath% -c Release
call %CmdSpec%