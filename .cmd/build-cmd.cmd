@echo off
call %~dp0config.cmd

@REM call %BuildLiterals%
@REM if errorlevel 1 goto:eof

: call %BuildZLib%
: if errorlevel 1 goto:eof

call %BuildCmdSln%
if errorlevel 1 goto:eof
