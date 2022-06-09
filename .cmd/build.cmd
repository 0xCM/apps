@echo off
call %~dp0config.cmd

call %BuildLiteralsCmd%
if errorlevel 1 goto:eof

call %~dp0build-zlib.cmd
if errorlevel 1 goto:eof

call %BuildMainCmd%
