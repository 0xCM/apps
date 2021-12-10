@echo off
call %~dp0config.cmd
call %BuildAppsCmd%
if errorlevel 1 goto:eof
