@echo off
set actor=dotnet-build
call %~dp0build-libs.cmd
if errorlevel 1 goto:eof

call %~dp0build-test.cmd
if errorlevel 1 goto:eof

call %~dp0build-apps.cmd
if errorlevel 1 goto:eof

call %~dp0build-cg.cmd
if errorlevel 1 goto:eof
