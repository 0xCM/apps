@echo off
call %~dp0config.cmd
call %BuildLibCmd%
call %BuildAppsCmd%
