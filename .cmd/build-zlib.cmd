@echo off
call %~dp0config.cmd
call %BuildLiteralsCmd%
call %BuildZLibCmd%

