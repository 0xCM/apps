@echo off
call %~dp0config.cmd
set SlnDir=%ProjectDir%
set SlnName=%ProjectSlnName%
call %TopDir%\.cmd\sln-config.cmd

call %SlnIntelShellCmd%
call %SlnIntelCoreCmd%
call %SlnIntelIntrinsicsCmd%
call %SlnIntelXedCmd%
call %SlnCgIntelCmd%
