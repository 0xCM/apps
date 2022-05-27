@echo off
call %~dp0config.cmd
call %BuildLibCmd%
if errorlevel 1 goto:eof

