@echo off
set ProjectId=cmd
set ShellId=zcmd
set WsId=z0
call %~dp0..\..\.cmd\config.cmd
set SlnPath=%CmdShellRoot%\%SlnName%
call %CmdScripts%\sln-config.cmd
