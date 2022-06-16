@echo off
set ProjectId=cmd
set ShellId=zcmd
call %~dp0..\..\.cmd\config.cmd
set SlnPath=%CmdShellRoot%\%SlnName%
call %CmdScripts%\sln-config.cmd
