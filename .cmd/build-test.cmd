@echo off
call %~dp0config.cmd
call %BuildTestCmd%
if errorlevel 1 goto:eof
