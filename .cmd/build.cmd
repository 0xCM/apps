@echo off
call %~dp0config.cmd

call %BuildMain%
if errorlevel 1 goto:eof
