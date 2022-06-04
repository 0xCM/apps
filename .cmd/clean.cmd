@echo off
call %~dp0config.cmd
set CmdSpec=rmdir %BuildRoot% /s/q
echo %CmdSpec%