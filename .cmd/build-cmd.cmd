@echo off
set ProjectId=cmd
set ShellId=zcmd
call %~dp0config.cmd

call %BuildZLibCmd%
if errorlevel 1 goto:eof

call %BuildShellCmd%
