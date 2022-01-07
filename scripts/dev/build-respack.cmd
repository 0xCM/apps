@echo off

set ProjectId=codegen.respack
call %ZDev%\.cmd\config.cmd
if errorlevel 1 goto:eof

echo %BuildCgProjectCmd%
: call %~dp0build-project.cmd
: if errorlevel 1 goto:eof



: call %~dp0deploy-%ProjectId%.cmd

