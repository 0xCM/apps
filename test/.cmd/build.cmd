@echo off
call %~dp0config.cmd
set CmdSpec=dotnet build %TestProjPath% -c Release
call %CmdSpec%