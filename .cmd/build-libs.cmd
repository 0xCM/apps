@echo off
call %~dp0config.cmd

call %BuildLiterals%
if errorlevel 1 goto:eof

call %BuildZLib%
if errorlevel 1 goto:eof

call %BuildLibs%
if errorlevel 1 goto:eof

echo Build Finished
