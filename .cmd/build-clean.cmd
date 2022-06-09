@echo off

set CmdSpec=rmdir %ZDev%\.build /s/q
call %CmdSpec%

call %~dp0build-all.cmd

