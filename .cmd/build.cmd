@echo off
call %~dp0config.cmd
call %BuildZLibCmd%
call %BuildMainCmd%
