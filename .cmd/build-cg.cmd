@echo off
call %~dp0config.cmd
call %BuildCgCmd%
if errorlevel 1 goto:eof
