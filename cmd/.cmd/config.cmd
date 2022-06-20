@echo off
set ProjectId=cmd
set ShellId=zcmd
set WsId=z0
call %Views%\z0\.cmd\config.cmd
set SlnPath=%CmdShellRoot%\%SlnName%
call %CmdScripts%\sln-config.cmd
