@echo off
call %~dp0config.cmd
call %BuildLibsCmd%
if errorlevel 1 goto:eof

