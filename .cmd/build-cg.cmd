@echo off
call %~dp0config.cmd
call %BuildCgSlnCmd%
if errorlevel 1 goto:eof
