@echo off
call %~dp0config.cmd
set SlnPath=%DevRoot%\dev\z0\z0.sln
set SlnTool=dotnet sln %SlnPath% add
