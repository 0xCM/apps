@echo off
call %~dp0config.cmd
set TestCmd=dotnet test
call %TestCmd%
