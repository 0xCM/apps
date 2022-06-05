@echo off
call %~dp0config.cmd
set SlnDir=%ProjectDir%
set SlnName=%ProjectSlnName%
call %TopDir%\.cmd\sln-config.cmd
call %TopDir%\.cmd\sln-add-shells.cmd
