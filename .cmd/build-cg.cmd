@echo off
call %~dp0config.cmd

call %BuildCgCommonCmd%
if errorlevel 1 goto:eof

call %BuildCgIntelCmd%
if errorlevel 1 goto:eof

call %BuildCgLlvmCmd%
if errorlevel 1 goto:eof

call %BuildCgShell%
if errorlevel 1 goto:eof

