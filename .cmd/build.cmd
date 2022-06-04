@echo off
call %~dp0config.cmd
call %~dp0build-zlib.cmd
call %BuildMainCmd%
