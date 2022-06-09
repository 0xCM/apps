@echo off
set SlnName=z0.sln
call %~dp0config.cmd
call %~dp0sln-config.cmd

call %SlnLiteralsCmd%
call %SlnZLibCmd%
call %SlnLibsCmd%
call %SlnCmdCmd%