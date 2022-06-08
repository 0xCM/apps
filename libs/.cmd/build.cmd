@echo off
call %~dp0config.cmd
call %BuildLibsCmd%
call %BuildRootProjectCmd%