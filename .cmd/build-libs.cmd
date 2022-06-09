@echo off
call %~dp0config.cmd
call %BuildZLibCmd%

if errorlevel 1 goto:eof
set ProjectId=libs
call %BuildLibsCmd%

