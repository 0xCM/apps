@echo off

set ProjectId=codegen.respack
call %ZDev%\.cmd\config.cmd
call %BuildCgProjectCmd%
if errorlevel 1 goto:eof

: call %~dp0build-project.cmd
: if errorlevel 1 goto:eof



: call %~dp0deploy-%ProjectId%.cmd

