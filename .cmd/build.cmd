@echo off
call %~dp0config.cmd

call %~dp0build-literals.cmd
if errorlevel 1 goto:eof

call %BuildMain%
if errorlevel 1 goto:eof
