@echo off
call %~dp0..\config.cmd
call %CleanProject%

if errorlevel 1 goto:eof
echo Cleaned %ShellPath% artifacts
