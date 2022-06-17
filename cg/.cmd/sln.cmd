@echo off
set SlnName=z0.cg.sln
call %~dp0config.cmd
call %CmdScripts%\sln-config.cmd

call %SlnCgIntelCmd%
call %SlnCgCommonCmd%
call %SlnCgLlvmCmd%
call %SlnCgShellCmd%
call %SlnCgTestCmd%