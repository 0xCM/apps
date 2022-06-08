@echo off
call %~dp0config.cmd
set SlnDir=%ProjectDir%
set SlnName=%ProjectSlnName%
call %CmdScripts%\sln-config.cmd
call %CmdScripts%\sln-add-libs.cmd
call %CmdScripts%\sln-add-cmd.cmd
