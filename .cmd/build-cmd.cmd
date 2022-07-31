@echo off
call %~dp0config.cmd

call %BuildCmdSln%
if errorlevel 1 goto:eof
