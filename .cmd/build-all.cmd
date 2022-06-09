@echo off

set ProjectId=cmd
set ShellId=zcmd
call %~dp0config.cmd

call %BuildZLibCmd%
if errorlevel 1 goto:eof

call %BuildCgCommonCmd%
if errorlevel 1 goto:eof

call %BuildCgIntelCmd%
if errorlevel 1 goto:eof

call %BuildCgLlvmCmd%
if errorlevel 1 goto:eof

call %BuildCgShell%
if errorlevel 1 goto:eof

call %BuildShellCmd%
if errorlevel 1 goto:eof

call %BuildTestsCmd%
if errorlevel 1 goto:eof

echo Done