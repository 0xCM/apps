@echo off
call %ZDev%\.cmd\build-libs.cmd
if errorlevel 1 goto:eof
call %ZDev%\.cmd\build-apps.cmd
if errorlevel 1 goto:eof

