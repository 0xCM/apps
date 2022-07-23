@echo off
call %~dp0config.cmd

call %BuildSlnRoot%
if errorlevel 1 goto:eof
