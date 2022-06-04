@echo off
call %~dp0config.cmd
set SlnDir=%TopDir%
set SlnName=z0.sln
call %~dp0sln-config.cmd
call %~dp0sln-add-libs.cmd
call %~dp0sln-add-tests.cmd
call %~dp0sln-add-shells.cmd
