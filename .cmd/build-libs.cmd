@echo off
call %~dp0config.cmd

call %BuildLiterals%
if errorlevel 1 goto:eof

@REM call %BuildZLib%
@REM if errorlevel 1 goto:eof

call %BuildLibs%
if errorlevel 1 goto:eof

echo Build Finished
