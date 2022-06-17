@echo off
set SlnName=z0.cmd.sln
call %~dp0config.cmd
call %SlnZLibCmd%
call %SlnLibsCmd%
call %SlnCmdShell%