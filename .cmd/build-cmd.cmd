@echo off
set ProjectId=cmd
set ShellId=zcmd
call %~dp0config.cmd
call %BuildZLibCmd%
call %BuildAreaShellCmd%
