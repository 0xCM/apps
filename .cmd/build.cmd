@echo off
call %~dp0config.cmd

call %~dp0build-zlib.cmd
if errorlevel 1 goto:eof

call %BuildCmdSln%
