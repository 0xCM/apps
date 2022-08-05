@echo off
set ProjectId=cmd
set ShellId=zcmd
set WsId=z0
call %~dp0..\..\scripts\config.cmd
set Artifacts=%SlnRoot%\artifacts
set Scripts=%SlnRoot%\scripts
set InstallBase=%Views%\tools\z0\zcmd
