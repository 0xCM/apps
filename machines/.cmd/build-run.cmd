@echo off
call %~dp0build.cmd
if errorlevel 1 goto:eof
call %~dp0run.cmd