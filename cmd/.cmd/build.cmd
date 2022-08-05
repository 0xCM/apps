@echo off
call %~dp0config.cmd
: call %BuildCmdShell%
call %PublishShell%
