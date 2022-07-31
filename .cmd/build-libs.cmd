@echo off
call %~dp0config.cmd

call %BuildLibs%
if errorlevel 1 goto:eof

echo Build Finished
